using System.Runtime.CompilerServices;
using UnityEngine;

public class ObserverProjectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public float lifetime = 3f;

    private GameObject player;
    private Vector2 direction;

    public void Initialize(Vector2 dir)
    {
        player = GameObject.FindGameObjectWithTag("Player");

        direction = dir.normalized;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("projectile hit player");

            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
            Debug.Log(playerHealth.currentHealth);
            Destroy(gameObject);
        }

    }
}