using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int startHealth = 4;
    public int currentHealth;

    public bool IsDead { get; private set; }

    public event Action<int, int> OnHealthChanged;
    public event Action OnDeath;

    void Awake()
    {
        currentHealth = startHealth;
    }

    public void TakeDamage(int amount)
    {
        if (IsDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (IsDead) return;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    private void Die()
    {
        if (IsDead) return;

        IsDead = true;
        OnDeath?.Invoke();

        Debug.Log("Player died");

        // Disable player control
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerDash>().enabled = false;
        GetComponent<PlayerInteract>().enabled = false;
    }
}