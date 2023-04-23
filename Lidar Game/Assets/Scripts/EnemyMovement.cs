/*
Name of Artifact: EnemyMovement.cs
Description: This script controls the Enemy's movement by utilizing the NavMeshAgent component to make the enemy chase the player within a specified listening range. If the player is outside the range, the enemy will stop chasing.
Programmer's Name: Sam Jerguson
Date Created: 1/29/2023
Dates Updated: 4/8/2023 - Description: Implemented a listening range for the enemy, making it chase the player only within the specified range. Author: Sam Jerguson
Preconditions: The script requires a reference to the player's Transform, a speed value, a NavMeshAgent component, and a chase range value.
Postconditions: The enemy will chase the player when they are within the chase range and stop chasing when they are outside the range.
Error/exception conditions: None.
Side Effects: The script modifies the enemy's destination and path using the NavMeshAgent component.
Invariants: The speed and chaseRange values must be non-negative.
Known faults: None.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public NavMeshAgent agent;
    public float chaseRange;

   // Set the enemy's speed using the NavMeshAgent component
    void Start()
    {
        agent.speed = speed;
    }

    // Update the enemy's destination and path based on the player's position
    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // If the player is within the chase range, set the enemy's destination to the player's position
        if (distanceToPlayer <= chaseRange)
        {
            agent.SetDestination(player.position);
        }
        // If the player is outside the chase range, reset the enemy's path
        else
        {
            agent.ResetPath();
        }
    }
}
