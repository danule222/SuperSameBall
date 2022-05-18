using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int points = 0;

    public void AddPoints(int points)
    {
        this.points += points;
    }
}
