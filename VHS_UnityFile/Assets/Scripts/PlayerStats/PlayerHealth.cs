using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public RawImage damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public GameObject deathUI;

    private bool isDamaged;

    void Start()
    {
        LoadPlayerData();
        damageImage.color = Color.clear;
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        isDamaged = true;
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            // Player is dead, handle death
            EndGame();
        }
        SavePlayerData();
    }

    void Update()
    {
        if (isDamaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        isDamaged = false;
    }

    void EndGame()
    {
        deathUI.SetActive(true);
        Time.timeScale = 0;
    }

    [System.Serializable]
    class PlayerData
    {
        public float[] position;
        public int health;
    }

    public void SavePlayerData()
    {
        PlayerData data = new PlayerData();
        data.position = new float[3];
        data.position[0] = transform.position.x;
        data.position[1] = transform.position.y;
        data.position[2] = transform.position.z;
        data.health = currentHealth;

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/playerData.json", jsonData);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(jsonData);

            Vector3 position = new Vector3(data.position[0], data.position[1], data.position[2]);
            transform.position = position;
            currentHealth = data.health;
            healthSlider.value = currentHealth;
        }
        else
        {
            Debug.LogWarning("No saved player data found.");
        }
    }
}
