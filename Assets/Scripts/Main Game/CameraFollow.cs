using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // INPUT_REQUIRED {Drag the player GameObject here in the Unity Inspector}
    public float smoothSpeed = 0.125f;
    public Vector3 offset; // INPUT_REQUIRED {Set the desired offset for the camera in the Unity Inspector}

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}