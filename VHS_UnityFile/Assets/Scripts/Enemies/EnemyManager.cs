using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject bigEnemyPrefab;
    public GameObject mediumEnemyPrefab;
    public GameObject smallEnemyPrefab;
    public Transform playerTransform;

    void Start()
    {
        // Create big enemies
        for (int i = 0; i < 3; i++)
        {
            GameObject bigEnemy = Instantiate(bigEnemyPrefab, new Vector3(i * 2, 0, 0), Quaternion.identity);
            bigEnemy.GetComponent<BigEnemy>().playerTransform = playerTransform;
        }

        // Create medium enemies
        for (int i = 0; i < 3; i++)
        {
            GameObject mediumEnemy = Instantiate(mediumEnemyPrefab, new Vector3(i * 2, 0, 2), Quaternion.identity);
            mediumEnemy.GetComponent<MediumEnemy>().playerTransform = playerTransform;
        }

        // Create small enemies
        for (int i = 0; i < 3; i++)
        {
            GameObject smallEnemy = Instantiate(smallEnemyPrefab, new Vector3(i * 2, 0, 4), Quaternion.identity);
            smallEnemy.GetComponent<SmallEnemy>().playerTransform = playerTransform;
        }
    }
}
