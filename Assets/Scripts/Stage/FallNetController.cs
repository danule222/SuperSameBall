using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallNetController : MonoBehaviour
{
    public GameObject stage;

    private StageController sC;

    private void Start()
    {
        sC = stage.GetComponent<StageController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sC.FinishGame();
        }
    }
}
