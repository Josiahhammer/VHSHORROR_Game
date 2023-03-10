using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMovement : MonoBehaviour
{
    public float moveSpeed = 100f;
    public float mouseSensitivity = 1000f;
    public float jumpForce = 100f;
    public float gravity = -9.81f;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private float xRotation = 0f;
    private float yRotation = 0f;

    public Light flashlight;

    public float frictionCoefficient = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }



    private void ApplyFriction()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            Vector3 frictionDirection = new Vector3(hit.normal.x, 0, hit.normal.z);
            Vector3 velocity = rb.velocity;
            Vector3 relativeVelocity = velocity - Vector3.Dot(velocity, frictionDirection) * frictionDirection;
            rb.velocity = relativeVelocity * frictionCoefficient;
        }
    }




    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY ;
        yRotation -= mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.GetChild(1).localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, -yRotation, 0f);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        moveDirection = transform.right * x + transform.forward * z;
        moveDirection.y = 0;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            flashlight.enabled = !flashlight.enabled;
        }

        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
        ApplyFriction();
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
