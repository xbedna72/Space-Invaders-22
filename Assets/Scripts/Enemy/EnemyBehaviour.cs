using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	public AudioClip clip;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		// Check if the other object is the projectile by its tag
		if (collision.tag == "Laser")
		{
			print("I'm Hit");

			// Allows playing an audio clip even if the Alien is destroyed and removed from the scene
			AudioSource.PlayClipAtPoint(clip, new Vector2(0.5f, 0.5f), 1.4f);

			// Destroy the Alien game object (the one this script is on)
			Destroy(gameObject);

			// Destroy the projectile game object
			Destroy(collision.gameObject);
		}
	}

	private void OnDestroy()
	{
		GameManager.Instance.EnemyHit();
	}
}
