using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public int health = 100;
	int currentHp;

	public GameObject deathEffect;

	public Slider slider;

    private void Start()
    {
		// slider�𖞃^���ɂ���
		slider.value = 1;
		// ���݂�HP���ő�HP�Ɠ�����
		currentHp = health;
    }

    // Collider�I�u�W�F�N�g��IsTrigger�Ƀ`�F�b�N�����邱��
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if(collision.gameObject.tag == "Enemy")
        {
			int damage = 20;
			Debug.Log("damage : " + damage);

			// ���݂�HP����_���[�W������
			currentHp = currentHp - damage;
			Debug.Log(("After currentHp : " + currentHp));

			// �ő�HP�ɂ����錻�݂�HP��slider�ɔ��f
			slider.value = (float)currentHp / (float)health;
			Debug.Log(("slider.value : " + slider.value));

		}
    }

    public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
