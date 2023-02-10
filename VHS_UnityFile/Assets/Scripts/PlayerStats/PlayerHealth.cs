using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        damageImage.color = Color.clear;
        currentHealth = startingHealth;
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
}
