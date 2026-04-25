using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;

    public bool isDashing = false;
    private float dashTime;
    private Vector2 dashDirection;

    private Rigidbody2D rb;
    public InputActionReference playerDash; 
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerDash.action.Enable();
    }

    private void OnDisable()
    {
        playerDash.action.Disable();
    }

    void Update()
    {
        if (playerDash.action.WasPressedThisFrame() && !isDashing)
        {
            StartDash();
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            rb.linearVelocity = dashDirection * dashSpeed;

            dashTime -= Time.fixedDeltaTime;
            if (dashTime <= 0f)
            {
                StopDash();
            }
        }
    }

    void StartDash()
    {
        isDashing = true;
        dashTime = dashDuration;

        dashDirection = playerMovement.move.action.ReadValue<Vector2>();

        // fallback if no input
        if (dashDirection == Vector2.zero)
            dashDirection = Vector2.right;

        dashDirection.Normalize();
    }

    void StopDash()
    {
        isDashing = false;
        rb.linearVelocity = Vector2.zero;
    }
}