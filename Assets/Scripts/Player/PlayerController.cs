using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private TMPro.TextMeshProUGUI ebis;
    [SerializeField]

    private int points = 0;
    private PlayerMovement movement;

    private void Start()
    {
        movement = gameObject.GetComponent<PlayerMovement>();
    }

    public void AddPoints(int points)
    {
        this.points += points;
        ebis.text = this.points.ToString();
    }

    public void SetSprint(int seconds, int intensity)
    {
        movement.SetSprint(seconds, intensity);
    }
}
