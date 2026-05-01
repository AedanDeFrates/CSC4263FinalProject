using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  private Vector2 moveInput;
private Rigidbody2D rb;

[SerializeField] private float moveForce = 10f;
[SerializeField] private float maxSpeed = 5f;

private void Awake()
{
    rb = GetComponent<Rigidbody2D>();
}

public void OnMove(InputValue value)
{
    moveInput = value.Get<Vector2>();
}

private void FixedUpdate()
{
    // Apply force
    rb.AddForce(moveInput * moveForce);

    // Clamp max speed so it doesn't go crazy
    if (rb.linearVelocity.magnitude > maxSpeed)
    {
        rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
    }
}
}
