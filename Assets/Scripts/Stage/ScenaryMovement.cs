using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryMovement : MonoBehaviour
{
    public float maxTilt;
    public float tiltSpeed;
    private Transform tr;
    private Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        originalRotation = tr.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //"Called" every 20 ms by default
    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0)
                tr.rotation = Quaternion.Lerp(tr.rotation, Quaternion.Euler(tr.rotation.x, tr.rotation.y, -maxTilt), tiltSpeed * Time.deltaTime);
            else
                tr.rotation = Quaternion.Lerp(tr.rotation, Quaternion.Euler(tr.rotation.x, tr.rotation.y, maxTilt), tiltSpeed * Time.deltaTime);
        }
        else
        {
            tr.rotation = Quaternion.Lerp(tr.rotation, Quaternion.Euler(tr.rotation.x, tr.rotation.y, tr.rotation.z), tiltSpeed * Time.deltaTime);
        }

        if (Input.GetButton("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0)
                tr.rotation = Quaternion.Lerp(tr.rotation, Quaternion.Euler(maxTilt, tr.rotation.y, tr.rotation.z), tiltSpeed * Time.deltaTime);
            else
                tr.rotation = Quaternion.Lerp(tr.rotation, Quaternion.Euler(-maxTilt, tr.rotation.y, tr.rotation.z), tiltSpeed * Time.deltaTime);
        }
        else
        {
            tr.rotation = Quaternion.Lerp(tr.rotation, Quaternion.Euler(tr.rotation.x, tr.rotation.y, tr.rotation.z), tiltSpeed * Time.deltaTime);
        }
    }
}
