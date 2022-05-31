using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EbiController : MonoBehaviour
{
    public int pointsValue;
    public float rotationSpeed;

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(.0f, Utils.NormalizeAngle(rotationSpeed * Time.deltaTime), .0f);
    }

    public int GetPointsValue()
    {
        return pointsValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().AddPoints(pointsValue);
            Destroy(gameObject);
        }
    }
}
