using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameSaveManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerHealth playerHealth;
    private string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/saveData.json";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SaveGame();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            LoadGame();
        }
    }

    [System.Serializable]
    private class SaveData
    {
        public Vector3 position;
        public Quaternion rotation;
        public int health;
    }

    private void SaveGame()
    {
        SaveData saveData = new SaveData();
        saveData.position = playerMovement.transform.position;
        saveData.rotation = playerMovement.transform.rotation;
        saveData.health = playerHealth.currentHealth;

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(savePath, json);
        Debug.Log("Game saved");
    }

    private void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            playerMovement.transform.position = saveData.position;
            playerMovement.transform.rotation = saveData.rotation;
            playerHealth.currentHealth = saveData.health;
            playerHealth.healthSlider.value = playerHealth.currentHealth;

            Debug.Log("Game loaded");
        }
        else
        {
            Debug.Log("Save file not found");
        }
    }
}
