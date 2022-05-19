using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int points = 0;

    [SerializeField]
    private TMPro.TextMeshProUGUI ebis;

    public void AddPoints(int points)
    {
        this.points += points;
        ebis.text = this.points.ToString();
    }
}
