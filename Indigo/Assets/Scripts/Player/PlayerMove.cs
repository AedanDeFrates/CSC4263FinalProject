using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public InputActionReference move;
    private Vector2 moveInput;


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
        rb.linearVelocity = moveInput * speed;
    }
}