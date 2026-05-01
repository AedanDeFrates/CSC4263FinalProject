using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public InputActionReference attackInput;

    private ItemEquip itemEquip;

    void Start()
    {
        itemEquip = GetComponent<ItemEquip>();
    }

    private void OnEnable()
    {
        attackInput.action.Enable();
    }

    private void OnDisable()
    {
        attackInput.action.Disable();
    }

    void Update()
    {
        if (attackInput.action.WasPressedThisFrame())
        {
            if(itemEquip.currentWeapon == null)
            {
                return;
            }
            IWeapon weapon = itemEquip.currentWeapon?.GetComponent<IWeapon>();
            weapon?.Attack();
        }
    }
}