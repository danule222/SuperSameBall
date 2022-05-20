using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject stageController;

    private StageController sC;

    public void Start()
    {
        sC = stageController.gameObject.GetComponent<StageController>();
    }

    public void RestartLevel()
    {
        sC.FinishGame();
    }

    public void ResumeLevel()
    {
        sC.ResumeGame();
    }

    public void Exit()
    {
        sC.ReturnToMenu();
    }
}
