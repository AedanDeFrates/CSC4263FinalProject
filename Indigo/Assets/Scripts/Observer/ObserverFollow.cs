using UnityEngine;

public class ObserverFollow : MonoBehaviour
{
    public bool mustFollow = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mustFollow = true;
            Debug.Log("follow entered");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mustFollow = false;
            Debug.Log("follow exited");
        }
    }
}
