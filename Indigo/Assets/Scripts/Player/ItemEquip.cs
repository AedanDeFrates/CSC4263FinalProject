using UnityEngine;

public class ItemEquip : MonoBehaviour
{
    public Transform weaponSocket;
    public Animator weaponSocketAnimator;

    public GameObject currentWeapon;
    private WeaponData currWeaponData;

    public void Equip(WeaponData data)
    {
        Unequip();

        currWeaponData = data;
        
        weaponSocketAnimator.runtimeAnimatorController = data.weaponAnimations;

        currentWeapon = Instantiate(
            data.equippedPrefab,
            weaponSocket.position,
            weaponSocket.rotation,
            weaponSocket
        );
    }

    private void Unequip()
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
            currentWeapon = null;
        }

        if (currWeaponData != null)
        {
            Instantiate(
                currWeaponData.worldPrefab,
                transform.position,
                Quaternion.identity
            );
        }

        currWeaponData = null;
    }
}