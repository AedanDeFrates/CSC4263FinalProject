using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCrouch : MonoBehaviour
{
    public float crouchSpeed = 2f;
    public bool isCrouching = false;
    public InputActionReference crouchInput;

    private void OnEnable()
    {
        crouchInput.action.Enable();
    }
    private void OnDisable()
    {
        crouchInput.action.Disable();
    }
    void Update()
    {
        if(crouchInput.action.IsPressed())
        {
            isCrouching = true;
        }
        else isCrouching = false;
    }
}
