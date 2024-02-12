using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatronoBase : MonoBehaviour
{

    private NavMeshAgent navMesh;
    public Transform player;
    public float followRange = 2f;
    public float circleRadius = 3f;
    private bool inRange = true;
    private Vector2 newPosition;

    private Animator animator;

    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        followPlayer();
    }

    void followPlayer()
    {
        // Calculate the distance between AI and player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the distance is greater than the followRange
        if (distanceToPlayer > followRange)
        {
            if (inRange)
            {
                newPosition = randomRadius();
                inRange = false;

               
            }

            // Move to a random position within the circle around the player
            Vector3 randomOffset = new Vector3(newPosition.x, 0f, newPosition.y);
            Vector3 targetPosition = player.position + randomOffset;

            // Set NavMeshAgent's destination and stopping distance
            navMesh.SetDestination(targetPosition);
            //navMesh.stoppingDistance = followRange;

            animator.SetBool("still", true);
        }
        else
        {
            // Check if the AI has reached its destination
            if (!navMesh.pathPending && navMesh.remainingDistance <= navMesh.stoppingDistance)
            {
                // Stop moving if the AI is within the followRange
                // navMesh.ResetPath();
                inRange = true;

                animator.SetBool("still", false);
            }
            else
            {
                animator.SetBool("still", true);
            }
        }
    }

    Vector2 randomRadius()
    {
        Vector2 randomCirclePoint = Random.insideUnitCircle * circleRadius;
        return randomCirclePoint;
    }
}
