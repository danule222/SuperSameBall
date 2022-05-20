using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public TMPro.TextMeshProUGUI ebis;

    private int points = 0;
    private PlayerMovement movement;

    private void Start()
    {
        movement = gameObject.GetComponent<PlayerMovement>();
    }

    public void AddPoints(int points)
    {
        this.points += points;
        ebis.text = "<mspace=0.5em>" + this.points.ToString("0000");
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
