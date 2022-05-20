using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [SerializeField]
    public TMPro.TextMeshProUGUI timerSeconds;
    [SerializeField]
    public TMPro.TextMeshProUGUI timerMiliseconds;
    [SerializeField]
    public TMPro.TextMeshProUGUI levelName;
    public int seconds;
    public string lName;

    private float counterStarTime;
    private float remainingTime;

    private void Start()
    {
        StartCounter();
        levelName.text = lName;
    }

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
