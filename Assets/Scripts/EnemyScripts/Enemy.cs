using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

	public int health = 100;
	int currentHp;

	public Slider slider2;

	public GameObject deathEffect;

	private void Start()
	{
		// slider�𖞃^���ɂ���
		slider2.value = 1;
		// ���݂�HP���ő�HP�Ɠ�����
		currentHp = health;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			int damage = 20;
			Debug.Log("damage : " + damage);

			// ���݂�HP����_���[�W������
			currentHp = currentHp - damage;
			Debug.Log(("After currentHp : " + currentHp));

			// �ő�HP�ɂ����錻�݂�HP��slider�ɔ��f
			slider2.value = (float)currentHp / (float)health;
			Debug.Log(("slider.value : " + slider2.value));

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
