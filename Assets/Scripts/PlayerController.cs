using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;

    Camera cam;
    PlayerMovement move;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        move = GetComponent<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // right click
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                // move our player to where we click
                move.Move(hit.point);
                // stop focusing any objects
            }
        }
        if (Input.GetMouseButtonDown(0)) // left click
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                // pickup gem/crystal/energy
                Debug.Log("Left Clicked");
            }
        }
    }
}