using System.Collections.Generic;
using UnityEngine;

public class AvailableItems : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> itemList = new List<GameObject>();
    public bool itemInRange = false;

    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Item"))
        {
            if (!itemList.Contains(other.gameObject))
            {
                itemList.Add(other.gameObject);
            }
            if(itemList.Count > 0)
            {
                itemInRange = true;
                Debug.Log("Items in range");
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            itemList.Remove(other.gameObject);
            if(itemList.Count == 0)
            {
                itemInRange = false;
                Debug.Log("No Items out of range");
            }
        }
    }
}