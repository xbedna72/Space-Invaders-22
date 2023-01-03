using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ShowPoints : MonoBehaviour
{
    private TextMeshProUGUI pointsText;
    public int score;

	void Start()
    {
        pointsText = gameObject.GetComponentInParent<TextMeshProUGUI>();
	}

	public void EnemyHit()
    {
        score += 1;
        pointsText.text = score.ToString();
		if (score == 27) //maximum amount of enemies
		{
			GameManager.Instance.GameOver();
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
