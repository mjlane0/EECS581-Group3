using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public NavMeshAgent agent;

    void Update()
    {
        //Vector3 direction = player.position - transform.position;
        //transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //transform.rotation = Quaternion.LookRotation(direction);
        agent.SetDestination(player.position);
    }
}
