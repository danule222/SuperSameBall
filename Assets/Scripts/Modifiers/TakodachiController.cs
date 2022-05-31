using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakodachiController : MonoBehaviour
{
    public float speed;
    public bool moves;
    public Vector3 startPoint;
    public Vector3 endPoint;

    private AudioSource sound;
    private bool returning = false;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (moves)
        {
            if (!returning)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPoint, speed);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPoint, speed);
            }

            if (Vector3.Distance(transform.position, endPoint) < 0.1f && !returning)
            {
                gameObject.transform.Rotate(new Vector3(.0f, 180.0f, .0f));
                returning = true;
            }
            else if (Vector3.Distance(transform.position, startPoint) < 0.1f && returning)
            {
                gameObject.transform.Rotate(new Vector3(.0f, 180.0f, .0f));
                returning = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>()
                .SetJump(20);

            sound.Play();
        }
    }
}
