using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    public InputActionReference look;

    private void OnEnable()
    {
        look.action.Enable();
    }

    private void OnDisable()
    {
        look.action.Disable();
    }

    void Update()
    {
        Vector2 input = look.action.ReadValue<Vector2>();

        Vector2 direction;

        if (input.magnitude <= 1.5f)
        {
            if (input.magnitude < 0.2f)
                return;

            direction = input;
        }
        else
        {
            Vector3 world = cam.ScreenToWorldPoint(new Vector3(
                input.x,
                input.y,
                -cam.transform.position.z
            ));

            direction = world - transform.position;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}