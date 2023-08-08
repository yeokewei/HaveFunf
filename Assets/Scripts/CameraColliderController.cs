using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColliderController : MonoBehaviour
{
    public Transform targetCamera;  // Drag and drop your main camera here in the Inspector

    private void Update()
    {
        if (targetCamera != null)
        {
            // Set the position of the collider GameObject to match the camera's position
            transform.position = targetCamera.position;
        }
    }
}