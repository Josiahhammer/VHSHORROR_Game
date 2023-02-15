using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInst : MonoBehaviour
{
    public GameObject playerPrefab;
    private GameObject playerInstance;

    void Start()
    {
        // Instantiate the prefab
        playerInstance = Instantiate(playerPrefab, transform.position, Quaternion.identity);

        // Get the NavMeshAgent component from the instantiated player
        NavMeshAgent navMeshAgent = playerInstance.GetComponent<NavMeshAgent>();

        // Assign the player transform to the NavMeshAgent component
        navMeshAgent.destination = playerInstance.transform.position;
    }

}
