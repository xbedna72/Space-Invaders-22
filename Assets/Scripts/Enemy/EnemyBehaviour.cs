using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	public AudioClip clip;

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Laser")
		{
			print("I'm Hit");

			AudioSource.PlayClipAtPoint(clip, new Vector2(0.5f, 0.5f), 1.4f);

			Destroy(gameObject);

			Destroy(collision.gameObject);

			GameManager.Instance.EnemyHit();
		}
	}
}
