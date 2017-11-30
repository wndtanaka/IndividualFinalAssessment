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
    public float panSpeed = 30f;
    public float panBorder = 10f;

    private float currentZoom = 10f;
    private float currentX = 0f;

    private void Update()
    {
        CameraFollow();
        //CameraPan();
    }

    void LateUpdate()
    {
        LateCameraFollow();
    }
    public void CameraFollow()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        if (Input.GetMouseButton(2))
        {
            Debug.Log("Middle Mouse Clicked!");
            currentX += Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        }
    }
    public void LateCameraFollow()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        transform.RotateAround(target.position, Vector3.up, currentX);
    }
    public void CameraPan()
    {
        if (Input.mousePosition.y >= Screen.height - panBorder)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.y <= panBorder)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.x >= Screen.width - panBorder)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.x <= panBorder)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
    }
}