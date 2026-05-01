using UnityEngine;
using System;
using UnityEditor.Callbacks;
using System.Numerics;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int startHealth = 4;
    public int currentHealth;

    public bool IsDead { get; private set; }

    public event Action<int, int> OnHealthChanged;
    public event Action OnDeath;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        rb.linearVelocity = new UnityEngine.Vector2(0,0);
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerLook>().enabled = false;
        GetComponent<PlayerDash>().enabled = false;
        GetComponent<PlayerInteract>().enabled = false;
    }
}