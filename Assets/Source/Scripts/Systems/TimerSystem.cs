using Kuhpik;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : GameSystem, IIniting, IUpdating
{
    [SerializeField] private float timeRemaining = 60;
    [SerializeField] private bool timerIsRunning = false;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject losePanel;

    private float bonusTime = 30f;

    void IIniting.OnInit()
    {
        timerIsRunning = true;
    }

    void IUpdating.OnUpdate()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                losePanel.SetActive(true);
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

    public void AddBonusTime()
    {
        timeRemaining += bonusTime;
        losePanel.SetActive(false);
        timerIsRunning = true;
    }

    public float GetRemainingTime()
    {
        return timeRemaining;
    }
}
