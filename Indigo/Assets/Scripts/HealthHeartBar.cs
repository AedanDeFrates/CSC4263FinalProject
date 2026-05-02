using System.Collections.Generic;
using UnityEngine;

public class HealthHeartBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerController playerController;
    List<HealthHeart> hearts = new List<HealthHeart>();

    public void DrawHearts()
    {
        ClearHearts();

        float maxHealthRemainder = playerController.maxHealth % 2;
        int heartsToMake = (int) ((playerController.maxHealth / 2) + maxHealthRemainder);

        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(playerController.health - (i*2), 0, 2);
            hearts[i].SetHeartImage((HearthStatus)heartStatusRemainder);
        }
        
        
    }
    

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HearthStatus.Empty);
        hearts.Add(heartComponent);
    }
    
    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DrawHearts();
    }

    // Update is called once per frame
    void Update()
    {
        // i need to call this via delegate instead to update the health ui when the player got hit
        DrawHearts();
    }
}
