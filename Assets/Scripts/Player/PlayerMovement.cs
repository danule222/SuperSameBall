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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (CanMove() && !Input.GetButton("Move camera"))
            SetForce();
    }

    private void SetForce()
    {
        axis = Math.Abs(Input.GetAxis("Vertical")) >= Math.Abs(Input.GetAxis("Horizontal"))
               ? Input.GetAxis("Vertical")
               : Math.Abs(Input.GetAxis("Horizontal") * .5f);

        Vector3 forwardCamera = mainCamera.transform.forward;
        forwardCamera.y = 0.0f;
        Vector3.Normalize(forwardCamera);

        Vector3 movement = new Vector3(0.0f, 0.0f, axis);
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
}
