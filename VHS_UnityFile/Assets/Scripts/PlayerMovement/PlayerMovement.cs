using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 10f;
    public float sprintSpeed = 15f;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private Vector3 trueMovement;
    public float jumpForce = 100f;
    private float moveSpeed;
    public float damping = 0.1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Detects keyboard press
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

        //Moves rigidbody in direction given above
        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
    }
    bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1.2f))
        {
            return true;
        }
        return false;
    }
}
