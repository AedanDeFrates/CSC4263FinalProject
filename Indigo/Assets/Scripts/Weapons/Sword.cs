using UnityEditor.Animations;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    public WeaponData data;
    private Animator animator;
    void Awake()
    {
        animator = GameObject.FindGameObjectWithTag("WeaponSocket").GetComponent<Animator>();
    }
    public void Attack()
    {
        animator.SetTrigger("Attack");
        Debug.Log("Swing Sword");
    }
}
