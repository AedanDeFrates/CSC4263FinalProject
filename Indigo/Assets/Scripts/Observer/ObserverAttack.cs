using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObserverAttack : MonoBehaviour
{

    public float attackCoolDown = 2f;
    private float lastAttackTime;

    public GameObject projectilePrefab;
    public GameObject player;
    public ObserverAgro observerAgro;
    void Start()
    {
        
    }
    void Update()
    {
        if(observerAgro.isAgro)
        {
            TryAttack();
        }
    }
    void TryAttack()
    {
        if(Time.time - lastAttackTime >= attackCoolDown)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }
    void Attack()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;

        GameObject proj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        ObserverProjectile projectileScript = proj.GetComponent<ObserverProjectile>();
        projectileScript.Initialize(direction);
    }
}
