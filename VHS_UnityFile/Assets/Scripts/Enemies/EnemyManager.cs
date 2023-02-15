using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject bigEnemyPrefab;
    public GameObject mediumEnemyPrefab;
    public GameObject smallEnemyPrefab;

    void Start()
    {
        // Create instances of the "BigEnemy", "MediumEnemy", and "SmallEnemy" classes
        GameObject bigEnemy = Instantiate(bigEnemyPrefab);
        GameObject mediumEnemy = Instantiate(mediumEnemyPrefab);
        GameObject smallEnemy = Instantiate(smallEnemyPrefab);

        // Add the instances to the scene
        bigEnemy.transform.position = new Vector3(36, 11, 26);
        mediumEnemy.transform.position = new Vector3(40, 20, 26);
        smallEnemy.transform.position = new Vector3(44, 11, 26);


    }
}

