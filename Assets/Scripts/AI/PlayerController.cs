using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    public Interactable focus;

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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetMouseButtonDown(1)) // right click for movement
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                // move our player to where we click
                move.Move(hit.point);
                // stop focusing any objects
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(0)) // left click for interacting
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                // will getting Interactable component from clicked object
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }
    void SetFocus(Interactable newFocus) // focusing player to interactable object and move player to the object
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
            move.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }
    void RemoveFocus() // removing focus when not click on interactable object
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        move.StopFollowingTarget();
    }
}