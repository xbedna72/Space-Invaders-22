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

	private Timer TimerObject;
	private PointsClass PointsObject;
	private TextMeshProUGUI EndScreenText;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(Instance);
		}
		Instance = this;

		TimerObject = Timer.GetComponentInChildren<Timer>();
		PointsObject = scoreText.GetComponentInParent<PointsClass>();
		EndScreenText = EndScreen.GetComponentInChildren<TextMeshProUGUI>();
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

	public void CloseEndScreen()
	{
		EndScreen.SetActive(false);
		MainMenu.SetActive(true);
	}

	#region GameWorkflow
	public void StartTheGame()
	{
		Player.SetActive(true);
		MainMenu.SetActive(false);
		StatusScreen.SetActive(true);
		TimerObject.StartTimer();
		PointsObject.ResetScore();
	}

	public void GameOver(bool won)
	{
		Player.SetActive(false);
		StatusScreen.SetActive(false);
		EndScreen.SetActive(true);
		EndScreenText.text = won ? "CONGRATULATIONS!!!\n\nYOU SAVED THE EARTH!!!" : "TIME'S UP!!!\n\nFINAL SCORE: " + scoreText.text;
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

	public void EnemyHit()
	{
		PointsObject.EnemyHit();
	}

	public void LevelUp(int _enemyHits)
	{
		float i = 0.3f;
		if (_enemyHits == 5)
		{
			foreach(var enemy in EnemiesGroup)
			{
				enemy.GetComponentInParent<EnemyController>().timeStep -= i;
				i -= 0.1f;
			}
		}

		if (_enemyHits == 10)
		{
			EnemiesGroup[0].GetComponentInParent<EnemyController>().moveDistance = 1.5f;
			EnemiesGroup[2].GetComponentInParent<EnemyController>().moveDistance = 1.5f;
		}

		i = 0.2f;
		if (_enemyHits == 15)
		{
			foreach (var enemy in EnemiesGroup)
			{
				enemy.GetComponentInParent<EnemyController>().timeStep -= i;
			}
			EnemiesGroup[1].GetComponentInParent<EnemyController>().moveDistance = 1.5f;
			EnemiesGroup[0].GetComponentInParent<EnemyController>().moveDistance = 2.5f;
			EnemiesGroup[2].GetComponentInParent<EnemyController>().moveDistance = 2.5f;
		}

		i = 0.3f;
		if (_enemyHits == 20)
		{
			foreach (var enemy in EnemiesGroup)
			{
				enemy.GetComponentInParent<EnemyController>().timeStep -= i;
				i -= 0.1f;
			}
		}
	}
	#endregion
}
