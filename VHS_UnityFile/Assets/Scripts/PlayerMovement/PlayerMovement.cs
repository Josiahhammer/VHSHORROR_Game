using System.IO;
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

        // Load saved position and rotation from file
        if (File.Exists(Application.persistentDataPath + "/player_data.json"))
        {
            string jsonData = File.ReadAllText(Application.persistentDataPath + "/player_data.json");
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonData);
            transform.position = playerData.position;
            transform.rotation = playerData.rotation;
        }
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

    // Save player position and rotation to file
    private void SavePlayerData()
    {
        PlayerData playerData = new PlayerData();
        playerData.position = transform.position;
        playerData.rotation = transform.rotation;
        string jsonData = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.persistentDataPath + "/player_data.json", jsonData);
    }

    private void OnApplicationQuit()
    {
        SavePlayerData();
    }

    private void OnDestroy()
    {
        SavePlayerData();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SavePlayerData();
        }
    }
}
