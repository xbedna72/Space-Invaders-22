using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public static EnemyManager Instance { get; private set; }

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
}
