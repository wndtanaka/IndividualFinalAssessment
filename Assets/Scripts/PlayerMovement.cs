using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent nav;
    // Use this for initialization
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 movePoint)
    {
        nav.SetDestination(movePoint);
    }
}