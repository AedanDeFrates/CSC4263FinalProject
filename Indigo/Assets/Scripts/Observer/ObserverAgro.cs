using UnityEngine;

public class ObserverAgro : MonoBehaviour
{
    public bool isAgro = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isAgro = true;
            Debug.Log("agro entered");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isAgro = false;
            Debug.Log("agro exited");
        }
    }
}