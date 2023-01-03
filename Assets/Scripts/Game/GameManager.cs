using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

    public GameObject[] EnemiesGroup;
	public GameObject Player;
	public TextMeshProUGUI scoreText;
	public GameObject MainMenu;
	public GameObject InfoScreenPanel;
	public GameObject EndScreen;
	public GameObject Timer;
	public GameObject StatusScreen;
	public GameObject EnemyGroupPrefab;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(Instance);
		}
		Instance = this;
	}

	void Start()
    {
		Player.SetActive(false);
		MainMenu.SetActive(true);
		InfoScreenPanel.SetActive(false);
		EndScreen.SetActive(false);
		StatusScreen.SetActive(false);
	}

	public void InfoScreen()
	{
		InfoScreenPanel.SetActive(true);
		MainMenu.SetActive(false);
	}

	public void CloseInfoScreen()
	{
		InfoScreenPanel.SetActive(false);
		MainMenu.SetActive(true);
	}

	public void StartTheGame()
	{
		Player.SetActive(true);
		MainMenu.SetActive(false);
		StatusScreen.SetActive(true);
		Timer.GetComponentInChildren<Timer>().StartTimer();
		scoreText.GetComponentInParent<ShowPoints>().ResetScore();
	}

	public void GameOver()
	{
		Debug.Log("End of the game");
		Player.SetActive(false);
		StatusScreen.SetActive(false);
		EndScreen.SetActive(true);
		EndScreen.GetComponentInChildren<TextMeshProUGUI>().text = "TIME'S UP!!!\nFINAL SCORE: " + scoreText.text;
	}

	public void ResetGame()
	{
		EndScreen.SetActive(false);
		MainMenu.SetActive(true);

		foreach(GameObject alians in EnemiesGroup)
		{
			Destroy(alians);
		}

		EnemiesGroup[0] = Instantiate(EnemyGroupPrefab, new Vector3(0f, 2f, 0f), Quaternion.identity);
		EnemiesGroup[1] = Instantiate(EnemyGroupPrefab, new Vector3(0f, 3f, 0f), Quaternion.identity);
		EnemiesGroup[2] = Instantiate(EnemyGroupPrefab, new Vector3(0f, 4f, 0f), Quaternion.identity);
	}

	public void CloseEndScreen()
	{
		EndScreen.SetActive(false);
		MainMenu.SetActive(true);
	}

	public void EnemyHit()
	{
		scoreText.GetComponentInParent<ShowPoints>().EnemyHit();
	}

	public void LevelUp(int _enemyHits)
	{
		float i = 0.1f;
		if (_enemyHits == 5)
		{
			foreach(var enemy in EnemiesGroup)
			{
				enemy.GetComponentInParent<EnemyController>().timeStep -= i;
				i += 0.1f;
			}
		}

		i = 0.5f;
		if (_enemyHits == 10)
		{
			foreach (var enemy in EnemiesGroup)
			{
				enemy.GetComponentInParent<EnemyController>().moveDistance += i;
				i += 0.1f;
			}
		}

		i = 0.5f;
		if (_enemyHits == 15)
		{
			foreach (var enemy in EnemiesGroup)
			{
				enemy.GetComponentInParent<EnemyController>().timeStep = i;
				enemy.GetComponentInParent<EnemyController>().moveDistance = i;
			}
		}

		i = 0f;
		if (_enemyHits == 20)
		{
			foreach (var enemy in EnemiesGroup)
			{
				enemy.GetComponentInParent<EnemyController>().moveDistance += i;
				i += 0.1f;
			}
		}

		i = 0f;
		if (_enemyHits == 25)
		{
			foreach (var enemy in EnemiesGroup)
			{
				enemy.GetComponentInParent<EnemyController>().timeStep -= i;
				i += 0.1f;
			}
		}
	}
}
