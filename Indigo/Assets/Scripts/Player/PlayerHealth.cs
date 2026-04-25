using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int startHealth = 4;
    public int currentHealth;

    public bool IsDead { get; private set; }

    // Events for UI / other systems
    //public event Action<int, int> OnHealthChanged;
    //public event Action OnDeath;

    void Awake()
    {
        currentHealth = startHealth;
    }

    public void TakeDamage(int amount)
    {
        if (IsDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        //OnHealthChanged?.Invoke(currentHealth, maxHealth);

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

        //OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    private void Die()
    {
        IsDead = true;
        //OnDeath?.Invoke();

        Debug.Log("Player died");

        // Disable movement / play animation / reload scene etc.
    }
}