using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePlatformController : MonoBehaviour
{
    public GameObject button;
    public Vector3 offPosition;
    public Vector3 onPosition;

    private ButtonController bC;

    private void Start()
    {
        bC = button.GetComponent<ButtonController>();
        transform.position = offPosition;
    }

    private void FixedUpdate()
    {
        if (bC.GetState())
        {
            transform.position = Vector3.Lerp(transform.position, onPosition, Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, offPosition, Time.deltaTime);
        }
    }
}
