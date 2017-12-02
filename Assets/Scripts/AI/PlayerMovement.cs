using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    Transform target; // target to follow
    NavMeshAgent nav; // reference to our navmesh
    Animator anim;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (target != null)
        {
            nav.SetDestination(target.position);
            FaceTarget();
        }
        if (!nav.pathPending)
        {
            if (nav.remainingDistance <= nav.stoppingDistance)
            {
                if (!nav.hasPath || nav.velocity.sqrMagnitude == 0f)
                {
                    anim.SetBool("isMoving", false);
                }
            }
        }
    }

    public void Move(Vector3 movePoint)
    {
        nav.SetDestination(movePoint);
        anim.SetBool("isMoving", true);
    }
    public void FollowTarget(Interactable newTarget)
    {
        nav.stoppingDistance = newTarget.radius * 0.7f;
        nav.updateRotation = false;
        target = newTarget.interactionTransform;
        anim.SetBool("isMoving", true);
    }
    public void StopFollowingTarget()
    {
        nav.stoppingDistance = 0f;
        nav.updateRotation = true;
        target = null;
        //  anim.SetBool("isMoving", false);
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}