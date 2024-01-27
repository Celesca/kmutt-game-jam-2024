using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 2.0f;
    public float arrivalThreshold = 0.1f;

    private int currentPatrolIndex = 0;

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (patrolPoints.Length != 2)
        {
            Debug.LogError("Please assign exactly 2 patrol points!");
            return;
        }

        Transform targetPatrolPoint = patrolPoints[currentPatrolIndex];

        MoveTowards(targetPatrolPoint.position);

        if (Vector2.Distance(transform.position, targetPatrolPoint.position) < arrivalThreshold)
        {
            // If the monster has reached the patrol point, switch to the next one
            currentPatrolIndex = 1 - currentPatrolIndex; // Toggle between 0 and 1
        }
    }

    private void MoveTowards(Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}