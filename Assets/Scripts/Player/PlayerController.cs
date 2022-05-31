using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public TMPro.TextMeshProUGUI ebis;
    [SerializeField]
    public TMPro.TextMeshProUGUI totalEbis;
    public GameObject stageController;

    private int points = 0;
    private int totalPoints = 0;
    private PlayerMovement movement;
    private StageController sC;

    private void Start()
    {
        movement = gameObject.GetComponent<PlayerMovement>();
        totalEbis.text = "<mspace=0.5em>" + totalPoints.ToString("0000");
        sC = stageController.GetComponent<StageController>();
    }

    private void Update()
    {
        CheckIfBROActivated();
    }

    void OnEnable()
    {
        if (SceneManager.GetActiveScene().name.Equals("Playground"))
        {
            PlayerPrefs.SetInt("totalEbis", 0);
        }
        else
        {
            totalPoints = PlayerPrefs.GetInt("totalEbis");
        }
    }

    private void OnDisable()
    {
        if (sC.IsStageCompleted())
        {
            PlayerPrefs.SetInt("totalEbis", totalPoints);
        }
    }

    private void CheckIfBROActivated()
    {
        if (sC.IsBROActive())
        {
            sC.CompleteStage();
        }
    }

    public int GetPoints() => points;

    public void AddPoints(int points)
    {
        this.points += points;
        totalPoints += points;
        ebis.text = "<mspace=0.5em>" + this.points.ToString("0000");
        totalEbis.text = "<mspace=0.5em>" + totalPoints.ToString("0000");
    }

    public void SetSprint(int seconds, int intensity)
    {
        movement.Sprint(seconds, intensity);
    }

    public void SetJump(int intensity)
    {
        movement.Jump(intensity);
    }
}
