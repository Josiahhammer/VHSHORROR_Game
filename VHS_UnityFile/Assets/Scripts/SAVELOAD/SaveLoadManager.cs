using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    private string saveFilePath;

    private void Start()
    {
        // Set the file path for saving/loading the game data
        saveFilePath = Application.persistentDataPath + "/savedata.json";
    }

    private void Update()
    {
        // Check if the "i" key is pressed to save the game data
        if (Input.GetKeyDown(KeyCode.I))
        {
            SaveGameData();
        }

        // Check if the "o" key is pressed to load the game data
        if (Input.GetKeyDown(KeyCode.O))
        {
            LoadGameData();
        }
    }

    private void SaveGameData()
    {
        // Create a new game data object and fill it with the current player transform and health values
        GameData gameData = new GameData();
        gameData.playerTransform = transform.position;
        gameData.playerHealth = GetComponent<PlayerHealth>().currentHealth;

        // Convert the game data object to a JSON string
        string jsonData = JsonUtility.ToJson(gameData);

        // Write the JSON string to a file
        File.WriteAllText(saveFilePath, jsonData);

        Debug.Log("Game data saved.");
    }

    private void LoadGameData()
    {
        // Check if the save file exists
        if (File.Exists(saveFilePath))
        {
            // Read the JSON string from the file
            string jsonData = File.ReadAllText(saveFilePath);

            // Convert the JSON string to a game data object
            GameData gameData = JsonUtility.FromJson<GameData>(jsonData);

            // Set the player transform and health values to the values stored in the game data object
            transform.position = gameData.playerTransform;
            GetComponent<PlayerHealth>().currentHealth = gameData.playerHealth;
            GetComponent<PlayerHealth>().healthSlider.value = gameData.playerHealth;

            Debug.Log("Game data loaded.");
        }
        else
        {
            Debug.Log("Save file not found.");
        }
    }
}

// Define a data structure to hold the saved game data
[System.Serializable]
public class GameData
{
    public Vector3 playerTransform;
    public int playerHealth;
}
