using System.IO;
using UnityEngine;

public class PlayerSaveLoad : MonoBehaviour
{
    private string saveFileName = "save.json";


        public SaveLoadManager saveLoadManager;

        private bool isAlive;

        private PlayerHealth playerHealth;
        private PlayerMovement playerMovement;

        private void Start()
        {
            playerHealth = GetComponent<PlayerHealth>();
            playerMovement = GetComponent<PlayerMovement>();
            isAlive = true;
        }

    public void SavePlayerData(PlayerMovement playerMovement, PlayerHealth playerHealth)
    {
        if(isAlive == true)
        {
            // Create a data object to hold the player data
            PlayerData playerData = new PlayerData
            {
                position = playerMovement.transform.position,
                rotation = playerMovement.transform.rotation,
                health = playerHealth.currentHealth
            };

            // Serialize the data object to JSON
            string json = JsonUtility.ToJson(playerData, true);

            // Write the JSON string to a file
            File.WriteAllText(GetSaveFilePath(), json);
        }
    }

    public void LoadPlayerData(PlayerMovement playerMovement, PlayerHealth playerHealth)
    {
        if(isAlive == true)
        {
            // Read the JSON string from the save file
            string json = File.ReadAllText(GetSaveFilePath());

            // Deserialize the JSON string to a data object
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            // Set the player's position and rotation
            playerMovement.transform.position = playerData.position;
            playerMovement.transform.rotation = playerData.rotation;

            // Set the player's health
            playerHealth.currentHealth = playerData.health;
            playerHealth.healthSlider.value = playerData.health;

            if (playerData.health <= 0)
            {
                // If the player's health is 0 or less, set it to 100
                playerHealth.currentHealth = 100;
            }
        }
    }

    private string GetSaveFilePath()
    {
        // Get the path to the save file in the persistent data path
        return Path.Combine(Application.persistentDataPath, saveFileName);
    }

    public void Update(PlayerMovement playerMovement)
    {
        if (playerHealth.currentHealth <= 0)
        {
            isAlive = false;
        }
        else if (playerHealth.currentHealth > 0)
        {
            isAlive = true;
        }
            // Save the game when the "i" key is pressed
            if (Input.GetKeyDown(KeyCode.I))
        {
            SavePlayerData(FindObjectOfType<PlayerMovement>(), FindObjectOfType<PlayerHealth>());
        }

        // Load the game when the "o" key is pressed
        if (Input.GetKeyDown(KeyCode.O))
        {
            LoadPlayerData(FindObjectOfType<PlayerMovement>(), FindObjectOfType<PlayerHealth>());
        }
    }
}

// A data object to hold the player data
[System.Serializable]
public class PlayerData
{
    public Vector3 position;
    public Quaternion rotation;
    public int health;
}
