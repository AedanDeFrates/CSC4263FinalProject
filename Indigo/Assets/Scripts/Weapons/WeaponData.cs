using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Items/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string itemName;

    public GameObject worldPrefab;
    public GameObject equippedPrefab;
    public AnimatorController weaponAnimations;

    public int damage;
}
