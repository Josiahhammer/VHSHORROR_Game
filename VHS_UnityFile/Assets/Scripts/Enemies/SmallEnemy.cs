using UnityEngine;

public class SmallEnemy : Enemy
{
    public float moveSpeed;
    public int health;
    public Transform playerTransform;
    public float damageRange = 2f;

    void Update()
    {
        // Move the big enemy towards the player
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);

        // If the big enemy is close enough to the player, damage them
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance <= damageRange)
        {
            playerTransform.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}

