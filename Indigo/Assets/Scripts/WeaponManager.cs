using System;
using UnityEngine;
using GameObject = UnityEngine.GameObject;

using UnityEngine;

public enum WeaponType
{
    Sword,
    Bow,
    Boomerang
}

[System.Serializable]
public struct WeaponEntry
{
    public WeaponType type;
    public GameObject weaponObject;
    public float damage;
    public float cooldown;
}

public class WeaponManager : MonoBehaviour
{
 
    public static event System.Action<WeaponEntry> OnWeaponChanged;

    public WeaponEntry[] weapons;

    private WeaponType currentWeapon;
    private WeaponEntry currentWeaponData;

    private float lastAttackTime;

    private void OnEnable()
    {
        PlayerController.OnWeaponSelected += SelectWeapon;
    }

    private void OnDisable()
    {
        PlayerController.OnWeaponSelected -= SelectWeapon;
    }

    private void Start()
    {
        SwitchWeapon(WeaponType.Sword);
    }

    private void SelectWeapon(int index)
    {
        if (!Enum.IsDefined(typeof(WeaponType), index))
            return;

        SwitchWeapon((WeaponType)index);
    }

    private void SwitchWeapon(WeaponType type)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            bool isSelected = weapons[i].type == type;

            if (weapons[i].weaponObject != null)
                weapons[i].weaponObject.SetActive(isSelected);

            if (isSelected)
                currentWeaponData = weapons[i];
        }

        currentWeapon = type;
        OnWeaponChanged?.Invoke(currentWeaponData);
    }
}
