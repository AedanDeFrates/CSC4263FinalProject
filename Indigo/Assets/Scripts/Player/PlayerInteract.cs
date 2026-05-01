using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public InputActionReference interactionInput;
    public GameObject InteractionRadius;
    private AvailableItems availableItems;
    private PlayerCrouch playerCrouch;
    
    void Start()
    {
        availableItems = InteractionRadius.GetComponent<AvailableItems>();
        playerCrouch = GetComponent<PlayerCrouch>();
    }

    private void OnEnable()
    {
        interactionInput.action.Enable();
    }

    private void OnDisable()
    {
        interactionInput.action.Disable();
    }

    void Update()
    {
        if (interactionInput.action.WasPressedThisFrame())
        {
            if (playerCrouch.isCrouching && availableItems.itemList.Count > 0)
            {
                GameObject item = availableItems.itemList[0];

                WeaponPickup pickup = item.GetComponent<WeaponPickup>();
                if(pickup == null) return;
                GetComponent<ItemEquip>().Equip(pickup.weaponData);

                availableItems.itemList.Remove(item);
                Destroy(item);
            }
        }
    }
}