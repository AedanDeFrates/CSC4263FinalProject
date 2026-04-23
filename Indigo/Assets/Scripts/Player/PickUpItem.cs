using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Item") )
        {
            Debug.Log("item in radius");
        }
    } 
} 