using UnityEngine;

public class ObserverFlee : MonoBehaviour
{
    public bool mustFlee = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            mustFlee = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            mustFlee = false;
        }
    }
}