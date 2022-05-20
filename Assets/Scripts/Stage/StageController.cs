using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    public TMPro.TextMeshProUGUI timerSeconds;
    [SerializeField]
    public TMPro.TextMeshProUGUI timerMiliseconds;
    public int seconds;

    private float counterStarTime;
    private float remainingTime;

    private void Update()
    {
        HandleCounter();
    }

    private void HandleCounter()
    {
        remainingTime =  (counterStarTime - Time.time) + seconds;
        float miliseconds = (int)remainingTime - remainingTime;

        if (remainingTime <= .0f)
        {
            timerSeconds.text = "<mspace=0.5em>" + "00";
            timerMiliseconds.text = "<mspace=0.5em>" + ":00";
            FinishGame();
        }
        else
        {
            timerSeconds.text = "<mspace=0.5em>" + Math.Truncate(remainingTime).ToString("00");
            timerMiliseconds.text = "<mspace=0.5em>" + miliseconds.ToString(".00")
                .Replace("-1", "")
                .Replace("-", "")
                .Replace(".", ":")
                .Replace(",", ":");
        }
    }

    public void StartCounter()
    {
        counterStarTime = Time.time;
    }

    public void FinishGame()
    {

    }
}
