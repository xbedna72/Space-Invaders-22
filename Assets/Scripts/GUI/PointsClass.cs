using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class PointsClass : MonoBehaviour
{
    private TextMeshProUGUI pointsText;
    public int score;

	private void Awake()
	{
		pointsText = gameObject.GetComponentInParent<TextMeshProUGUI>();
	}

	public void EnemyHit()
    {
        score += 1;
        pointsText.text = score.ToString();
		if (score == 27) //maximum amount of enemies
		{
			GameManager.Instance.GameOver(true);
			return;
		}
		GameManager.Instance.LevelUp(score);
    }

	public void ResetScore()
	{
		score = 0;
		pointsText.text = score.ToString();
	}
}
