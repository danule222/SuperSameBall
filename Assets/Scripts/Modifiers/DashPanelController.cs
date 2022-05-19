using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPanelController : MonoBehaviour
{
    public int duration;
    public int intensity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController pC = other.GetComponent<PlayerController>();

            pC.SetSprint(duration, intensity);
        }
    }
}
