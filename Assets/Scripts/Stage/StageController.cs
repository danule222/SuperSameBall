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
    public GameObject player;
    public string nextSceneName;
    public int seconds;
    public string lName;
    public int numberOfEbis;

    private PlayerController pC;
    private float counterStarTime;
    private float remainingTime;

    private void Start()
    {
        StartCounter();
        levelName.text = lName;
        pC = player.gameObject.GetComponent<PlayerController>();
    }

    private void Update()
    {
        HandleCounter();
        HandleInput();
        CheckEbis();
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

    private void HandleInput()
    {
        if (Input.GetButton("Cancel"))
        {
            ReturnToMenu();
        }
    }

    private void CheckEbis()
    {
        if (pC.GetPoints() >= numberOfEbis)
        {
            CompleteStage();
        }
    }

    public void StartCounter()
    {
        counterStarTime = Time.time;
    }

    public void CompleteStage()
    {
        if (!String.IsNullOrEmpty(nextSceneName))
            SceneManager.LoadScene(nextSceneName);
        else
            ReturnToMenu();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main menu");
    }

    public void FinishGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
