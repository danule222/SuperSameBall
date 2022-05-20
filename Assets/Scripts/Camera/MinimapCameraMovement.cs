using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;
    public float cameraHeight;

    private PlayerController pC;
    private CameraController cC;

    private void Start()
    {
        pC = player.GetComponent<PlayerController>();
        cC = mainCamera.GetComponent<CameraController>();
    }

    private void FixedUpdate()
    {
        SetPosition();
        SetRotation();
    }

    private void SetPosition()
    {
        transform.position =
            new Vector3(player.transform.position.x,
                        player.transform.position.y + cameraHeight,
                        player.transform.position.z);
    }

    private void SetRotation()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                                              cC.GetRotationAngles(),
                                              transform.rotation.eulerAngles.z);
    }
}
