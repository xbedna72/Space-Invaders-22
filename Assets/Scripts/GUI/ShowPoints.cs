using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ShowPoints : MonoBehaviour
{
    private TextMeshProUGUI pointsText;
    private int score;

	private void Awake()
	{
		score = 0;
	}

	void Start()
    {
        pointsText = gameObject.GetComponentInParent<TextMeshProUGUI>();
		pointsText.text = score.ToString();
	}

	public void EnemyHit()
    {
        score += 1;
        pointsText.text = score.ToString();
		GameManager.Instance.LevelUp(score);
    }
}
