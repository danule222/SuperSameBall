using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameObject mainCamera;

    private Rigidbody rb;
    private float axis;
    // Sprint
    private bool isSprinting = false;
    private float lastSprint;
    private int sprintDuration;
    private int sprintIntensity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (CanMove() && !Input.GetButton("Move camera"))
            SetForce();
        if (isSprinting)
            HandleSprint();
    }

    private void SetForce()
    {
        axis = Math.Abs(Input.GetAxis("Vertical")) >= Math.Abs(Input.GetAxis("Horizontal"))
               ? Input.GetAxis("Vertical")
               : Math.Abs(Input.GetAxis("Horizontal") * .5f);

        Vector3 forwardCamera = mainCamera.transform.forward;
        forwardCamera.y = 0.0f;
        Vector3.Normalize(forwardCamera);

        if (isSprinting)
        {
            rb.AddForce(mainCamera.transform.forward * (axis + (speed + sprintIntensity)));
        }
        else
            rb.AddForce(mainCamera.transform.forward * axis * speed);
    }

    private bool CanMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1f))
            return true;
        else
            return false;
    }

    private void HandleSprint()
    {
        if (Time.time - lastSprint >= sprintDuration)
        {
            isSprinting = false;
        }
    }

    public void Sprint(int seconds, int intensity)
    {
        lastSprint = Time.time;
        sprintDuration = seconds;
        sprintIntensity = intensity;
        isSprinting = true;
    }

    public void Jump(int intensity)
    {
        rb.AddForce(Vector3.up * (intensity * 1000));
    }
}
