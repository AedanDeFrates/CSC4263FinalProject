using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
public PlayerHealth playerHealth;
    public Image heartPrefab;
    public Transform heartContainer;

    private Image[] hearts;

    void Start()
    {
        CreateHearts();
        UpdateHearts(playerHealth.currentHealth, playerHealth.maxHealth);

        playerHealth.OnHealthChanged += UpdateHearts;
    }

    void CreateHearts()
    {
        hearts = new Image[playerHealth.maxHealth];

        for (int i = 0; i < playerHealth.maxHealth; i++)
        {
            hearts[i] = Instantiate(heartPrefab, heartContainer);
        }
    }

    void UpdateHearts(int current, int max)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < current;
        }
    }
}
