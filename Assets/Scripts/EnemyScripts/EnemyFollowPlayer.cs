using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour

{
   
    public float speed;
    public float rangeEyes;
    public float rangeShooting;
    public float fireRate = 1f;
    public float nextFireTime;
    public GameObject enemyBullet;
    public GameObject enemyFirePoint;
    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //player 近寄る関数　if player come to close rangeEyes of enemy
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < rangeEyes && distanceFromPlayer > rangeShooting)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if(distanceFromPlayer <= rangeShooting && nextFireTime < Time.time)
            {
            Instantiate(enemyBullet, enemyFirePoint.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
            }
        
    }
    //  こちらはエネミーのrangeEyesです。drawRangeEyes
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position,rangeEyes);
        Gizmos.DrawWireSphere(transform.position,rangeShooting);
    }
    
}
