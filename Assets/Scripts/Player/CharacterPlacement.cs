using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlacement : MonoBehaviour
{
    public GameObject parent;
    public float rotationSpeed;

    private Rigidbody targetRb;
    private float rotationAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = parent.transform.position;
        targetRb = parent.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = parent.transform.position;

        if (targetRb.velocity.magnitude > 0.3)
        {
            rotationAngle = Mathf.LerpAngle(Vector3.SignedAngle(Vector3.forward, targetRb.velocity, Vector3.up), rotationAngle, rotationSpeed * Time.deltaTime);
        }

        gameObject.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.up);
    }
}
