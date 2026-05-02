using UnityEngine;
using UnityEngine.UI;



public enum HearthStatus
{
    Empty =0,
    Half = 1,
    Full = 2,
}

public class HealthHeart : MonoBehaviour
{
    public Sprite fullHeart, emptyHeart, halfHeart;

    private Image heartImage;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    public void SetHeartImage(HearthStatus status)
    {
        switch (status)
        {
            case HearthStatus.Empty:
                heartImage.sprite = emptyHeart;
                break;
            case HearthStatus.Half:
                heartImage.sprite = halfHeart;
                break;
            case HearthStatus.Full:
                heartImage.sprite = fullHeart;
                break;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
