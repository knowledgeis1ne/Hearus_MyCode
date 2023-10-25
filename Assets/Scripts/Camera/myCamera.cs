using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCamera : MonoBehaviour
{
    public Transform targetTransform;
    public Vector3 CameraOffset;
    
    public float angleX = 9.0f;
    public float angleY = 180.0f;
    public float angleZ = 0.0f;

    void FixedUpdate()
    {
        transform.position = targetTransform.position + CameraOffset;
    }
}