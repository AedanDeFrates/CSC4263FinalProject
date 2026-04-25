using UnityEngine;

public enum ObserverState
{
    Idle,
    Chase,
    Flee,
    Stop
}

public class ObserverAI : MonoBehaviour
{
    public float moveSpeed = 1f;

    private ObserverState currState;
    private Rigidbody2D rb;

    public GameObject player;
    public ObserverAgro agro;
    public ObserverFlee flee;
    public ObserverFollow follow;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        currState = GetState();

        switch (currState)
        {
            case ObserverState.Idle:
                Idle();
                break;
            case ObserverState.Chase:
                Chase();
                break;
            case ObserverState.Flee:
                Flee();
                break;
            case ObserverState.Stop:
                StopMoving();
                break;
        }
    }

    ObserverState GetState()
    {

        if (flee.mustFlee)
        {
            return ObserverState.Flee;
        }
        if (follow.mustFollow)
        {
            return ObserverState.Stop;
        }
        if (agro.isAgro)
        {
            return ObserverState.Chase;
        }

        return ObserverState.Idle;
    }

    void Idle()
    {
        rb.linearVelocity = Vector2.zero;
    }

    void Chase()
    {
        if (player == null)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }

    void Flee()
    {
        if (player == null)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 direction = (transform.position - player.transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }

    void StopMoving()
    {
        rb.linearVelocity = Vector2.zero;
    }
}
