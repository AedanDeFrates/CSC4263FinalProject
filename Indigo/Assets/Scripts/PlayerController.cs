using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public float maxHealth;
    public float health;
    
    // Delegate (event)
    public static event Action<int> OnWeaponSelected;
    
    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Unity calls this automatically because Player Input uses "Send Messages"
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
    
    public void OnSelectWeapon1(InputValue value)
    {
        if (!value.isPressed) return;
        OnWeaponSelected?.Invoke(0);
    }

    public void OnSelectWeapon2(InputValue value)
    {
        if (!value.isPressed) return;
        OnWeaponSelected?.Invoke(1);
    }

    public void OnSelectWeapon3(InputValue value)
    {
        if (!value.isPressed) return;
        OnWeaponSelected?.Invoke(2);
    }
}
