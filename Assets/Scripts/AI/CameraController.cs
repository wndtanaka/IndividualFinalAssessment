using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float pitch = 2f;
    public float zoomSensitivity = 10f;
    public float minZoom = 5f;
    public float maxZoom = 20f;
    public float sensitivityX = 100f;

    private float currentZoom = 10f;
    private float currentX = 0f;

    private void Update()
    {
        CameraFollow();
    }

    void LateUpdate()
    {
        LateCameraFollow();
    }
    public void CameraFollow()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity; // camera zooming using axis of mousewheel
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom); // clamping min and max zoom

        if (Input.GetMouseButton(2)) // rotate camera with middle mouse button
        {
            currentX += Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        }
    }
    public void LateCameraFollow()
    {
        transform.position = target.position - offset * currentZoom; // position of the camera
        transform.LookAt(target.position + Vector3.up * pitch); // always look at the player
        transform.RotateAround(target.position, Vector3.up, currentX); // rotate camera around the player
    }
}