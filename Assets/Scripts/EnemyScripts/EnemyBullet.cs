using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    GameObject target;
    public int damage = 40;
    public float speed;
    public Rigidbody2D Rb;
    public GameObject impactEffect;

    void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        Rb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }
    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        Player player = hitInfo.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    


}
