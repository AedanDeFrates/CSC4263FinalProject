using UnityEngine;

public class Sword : MonoBehaviour
{
    public WeaponData data;
    public void Initialize(WeaponData data)
    {
        this.data = data;
    }
    public void Attack()
    {
        Debug.Log("Swing Sword");
    }
}
