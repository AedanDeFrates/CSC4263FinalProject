using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public bool isMoving;

    public Rigidbody2D rb;
    public InputActionReference move;
    private PlayerCrouch playerCrouch;
    private Vector2 moveInput;

    void Start()
    {
        playerCrouch = GetComponent<PlayerCrouch>();
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
    } 
    void FixedUpdate()
    {
        if(playerCrouch.crouchInput.action.IsPressed())
        {
            rb.linearVelocity = moveInput * playerCrouch.crouchSpeed;
        }
        else { rb.linearVelocity = moveInput * speed; }
    }
}