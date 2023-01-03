using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float timeRemaining;
    public TextMeshProUGUI timeText;
    bool IsActive = false;

    public void StartTimer()
    {
		timeRemaining = 60;
		IsActive = true;
        Debug.Log("Start timer");
    }

    void Update()
    {
        if (IsActive)
        {
			if (timeRemaining > 0)
			{
					Debug.Log(timeRemaining.ToString());
					timeRemaining -= Time.deltaTime;
					DisplayTime(timeRemaining);
			}
			else
			{
				IsActive = false;
                timeRemaining = 0;
				GameManager.Instance.GameOver(false);
			}
		}
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
		float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}
}
