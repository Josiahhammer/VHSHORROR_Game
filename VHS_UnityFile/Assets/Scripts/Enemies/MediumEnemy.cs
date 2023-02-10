using UnityEngine;

public class MediumEnemy : MonoBehaviour
{
    //These are unique to the medium enemy
    public float moveSpeed = 3f;
    public int health = 200;
    public float damageRange = 2f;
    public int damage = 40;
    public float attackCooldown = 1f;
    private float attackTimer;

    //These are not unique
    public Transform playerTransform;
    private Vector3 direction;
    void Start()
    {
        // Assign the player's Transform component to the playerTransform variable
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        // Move the big enemy towards the player
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);

        // Calculate the angle between the enemy's forward direction and the direction towards the player
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // Rotate the enemy towards the player on the y-axis only
        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10);

        // If the big enemy is close enough to the player and the attack timer is not active, damage them
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance <= damageRange && attackTimer <= 0)
        {
            playerTransform.GetComponent<PlayerHealth>().TakeDamage(damage);
            attackTimer = attackCooldown;
        }

        // Decrement the attack timer
        attackTimer -= Time.deltaTime;
    }
}
