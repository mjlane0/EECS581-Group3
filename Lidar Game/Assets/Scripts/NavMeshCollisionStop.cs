using UnityEngine;
using UnityEngine.AI;

public class AvoidNavMeshOverlap : MonoBehaviour
{
    private NavMeshAgent navAgent;

    void Start()
    {
        // Get the NavMeshAgent component from this game object
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Check if the NavMeshAgent is currently moving
        if (navAgent.velocity != Vector3.zero)
        {
            // Get all NavMeshAgents within a certain distance from this object
            Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);

            // Loop through all the colliders
            foreach (Collider collider in colliders)
            {
                // Check if the collider is a NavMeshAgent
                if (collider.GetComponent<NavMeshAgent>())
                {
                    // Calculate the distance between this object and the collider
                    float distance = Vector3.Distance(transform.position, collider.transform.position);

                    // If the distance is less than the sum of the radii of the two NavMeshAgents, stop this NavMeshAgent
                    if (distance < navAgent.radius + collider.GetComponent<NavMeshAgent>().radius)
                    {
                        navAgent.isStopped = true;
                        break;
                    }
                    else
                    {
                        navAgent.isStopped = false;
                    }
                }
            }
        }
    }
}