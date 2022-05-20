using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    CameraMovement cM;

    private void Start()
    {
        cM = gameObject.GetComponent<CameraMovement>();
    }

    public float GetRotationAngles()
    {
        return cM.angle;
    }
}
