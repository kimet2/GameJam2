using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;

    void Update()
    {
        cameraSpeed += 0.1f * Time.deltaTime;
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
    }
}
