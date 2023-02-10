using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Rigidbody rb;
    private Animation anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        // Apply the force of gravity to the Rigidbody component
        rb.AddForce(Physics.gravity * rb.mass);

        // Play the animation based on the Rigidbody's velocity
        if (rb.velocity.y < 0)
        {
            anim.Play("Fall");
        }
        else if (rb.velocity.y > 0)
        {
            anim.Play("Jump");
        }
        else
        {
            anim.Play("Idle");
        }
    }
}