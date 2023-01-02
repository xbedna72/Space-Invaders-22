using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

    public GameObject[] EnemiesList;
	public TextMeshProUGUI scoreText;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(Instance);
		}
		Instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {

	}

	private void Update()
	{
		
	}

	public void EnemyHit()
	{
		scoreText.GetComponentInParent<ShowPoints>().EnemyHit();
	}

	public void LevelUp(int _enemyHits)
	{
		float i = 0f;
		if (_enemyHits == 5)
		{
			foreach(var enemy in EnemiesList)
			{
				enemy.GetComponentInParent<EnemyController>().timeStep -= i;
				i += 0.1f;
			}
		}

		i = 0f;
		if (_enemyHits == 10)
		{
			foreach (var enemy in EnemiesList)
			{
				enemy.GetComponentInParent<EnemyController>().moveDistance += i;
				i += 0.1f;
			}
		}

		i = 0f;
		if (_enemyHits == 15)
		{
			foreach (var enemy in EnemiesList)
			{
				enemy.GetComponentInParent<EnemyController>().timeStep -= i;
				i += 0.1f;
			}
		}

		i = 0f;
		if (_enemyHits == 20)
		{
			foreach (var enemy in EnemiesList)
			{
				enemy.GetComponentInParent<EnemyController>().moveDistance += i;
				i += 0.1f;
			}
		}

		i = 0f;
		if (_enemyHits == 25)
		{
			foreach (var enemy in EnemiesList)
			{
				enemy.GetComponentInParent<EnemyController>().timeStep -= i;
				i += 0.1f;
			}
		}
	}
}
