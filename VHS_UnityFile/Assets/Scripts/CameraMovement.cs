using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float mouseSensitivity = 2.0f;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        float horizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        target.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * mouseSensitivity;
        target.Rotate(-vertical, 0, 0);

        transform.LookAt(target);
    }
}
