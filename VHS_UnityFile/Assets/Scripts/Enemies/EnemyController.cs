using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
   /* public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundLayer, playerLayer;

    // Patrol State
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Attack Player
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public GameObject projectilePos;

    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        // Patrol State
        if (!playerInSightRange && !playerInAttackRange) Patrol();
        // Patrol State
        if (playerInSightRange && !playerInAttackRange) Chase();
        // Patrol State
        if (playerInSightRange && playerInAttackRange) Attack();
    }

    private void Patrol()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceWalkPoint = transform.position - walkPoint;

        // Walkpoint reached
        if(distanceWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

    }

    private void SearchWalkPoint()
    {
        // Calculate new point
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayer))
            walkPointSet = true;
    }

    private void Chase()
    {

    }

    private void Attack()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

*/
}
