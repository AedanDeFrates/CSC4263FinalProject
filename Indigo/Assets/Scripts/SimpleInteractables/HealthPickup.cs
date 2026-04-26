using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int heal_amount = 1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.Heal(heal_amount);
            Destroy(gameObject);
        }
    }
}
