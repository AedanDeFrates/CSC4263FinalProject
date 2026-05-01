using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public bool isMoving = false;

    public Rigidbody2D rb;
    public InputActionReference move;
    private PlayerCrouch playerCrouch;
    private PlayerDash playerDash;
    private Vector2 moveInput;
    

    void Start()
    {
        playerCrouch = GetComponent<PlayerCrouch>();
        playerDash = GetComponent<PlayerDash>();
    }
    private void OnEnable()
    {
        move.action.Enable();
    }
    private void OnDisable()
    {
        move.action.Disable();
    }
    void Update()
    {
        moveInput = move.action.ReadValue<Vector2>();
        isMoving = moveInput.sqrMagnitude > 0.01f;
    } 
    void FixedUpdate()
    {
        if(playerDash.isDashing)
        {
            return;
        }

        if(playerCrouch.crouchInput.action.IsPressed())
        {
            rb.linearVelocity = moveInput * playerCrouch.crouchSpeed;
        }

        else { rb.linearVelocity = moveInput * speed; }
    }
}