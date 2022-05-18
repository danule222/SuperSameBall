using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject ball;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    public float rotationSpeed;
    public float back;
    public float angle;
    public float tiltSpeed;
    public float tiltMax;

    private float tiltZAngle = 0;
    private float tiltY = 0;

    public float bruh;

    private float yVelocity = 0.0f;

    private void Start()
    {
        SetPosition();
    }

    private void FixedUpdate()
    {
        SetAngleOfRotation();
        SetPosition();
        SetRotation();
        TiltEffect();
    }

    private void TiltEffect()
    {
        // Horizontal tilt
        if (Input.GetAxis("Horizontal") != 0)
            tiltZAngle = Mathf.LerpAngle(tiltZAngle, Input.GetAxis("Horizontal") * tiltMax, Time.deltaTime * tiltSpeed);
        else
            tiltZAngle = Mathf.LerpAngle(tiltZAngle, .0f, Time.deltaTime * tiltSpeed);

        transform.Rotate(new Vector3(.0f, .0f, tiltZAngle));

        // Vertical tilt
        if (Input.GetAxis("Vertical") != 0)
            tiltY = Mathf.Lerp(tiltY, -Input.GetAxis("Vertical"), Time.deltaTime * tiltSpeed);
        else
            tiltY = Mathf.Lerp(tiltY, .0f, Time.deltaTime * tiltSpeed);
    }

    private void SetAngleOfRotation()
    {
        float rotationSpeedAux = rotationSpeed;
        if (Input.GetButton("Move camera"))
            rotationSpeedAux += 4.0f;

        if (Input.GetAxis("Vertical") >= 0)
        {
            angle = Utils.NormalizeAngle(angle + Input.GetAxis("Horizontal") * rotationSpeedAux);
        }
        else
        {
            if (Vector3.Angle(gameObject.transform.forward.normalized, ball.GetComponent<Rigidbody>().velocity.normalized) > 20.0f)
            {
                angle = Utils.NormalizeAngle(Mathf.SmoothDampAngle(angle, Utils.GetOppostieAngle(angle), ref yVelocity, back));
            }
        }
    }

    private void SetPosition()
    {
        Vector3 posOff = new Vector3(positionOffset.x, positionOffset.y + tiltY, positionOffset.z);

        gameObject.transform.position = ball.transform.position + posOff;
    }

    private void SetRotation()
    {
        transform.LookAt(ball.transform.position);
        transform.rotation *= Quaternion.Euler(rotationOffset.x, rotationOffset.y, rotationOffset.z);

        transform.RotateAround(ball.transform.position, Vector3.up, angle);
    }
}
