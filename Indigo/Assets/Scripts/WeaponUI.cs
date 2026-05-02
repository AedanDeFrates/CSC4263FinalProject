using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using System.Collections;
public class WeaponUI : MonoBehaviour
{
    public Image swordImage;
    public Image bowImage;
    public Image boomerangImage;
    
    public Image swordImageFill;
    public Image bowImageFill;
    public Image boomerangImageFill;
    
    
    private Coroutine currentFillRoutine;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void OnEnable()
    {
        WeaponManager.OnWeaponChanged += UpdateUI;
    }

    private void OnDisable()
    {
        WeaponManager.OnWeaponChanged -= UpdateUI;
    }

    private void UpdateUI(WeaponEntry weapon)
    {
        // reset all to full
        swordImageFill.fillAmount = 1;
        bowImageFill.fillAmount = 1;
        boomerangImageFill.fillAmount = 1;

        // stop previous animation if running
        if (currentFillRoutine != null)
            StopCoroutine(currentFillRoutine);

        // choose which one to animate
        Image targetImage = null;

        switch (weapon.type)
        {
            case WeaponType.Sword:
                targetImage = swordImageFill;
                break;

            case WeaponType.Bow:
                targetImage = bowImageFill;
                break;

            case WeaponType.Boomerang:
                targetImage = boomerangImageFill;
                break;
        }

        if (targetImage != null)
        {
            targetImage.fillAmount = 1;
            currentFillRoutine = StartCoroutine(AnimateFill(targetImage, 0f, 1f));
        }
        
    }
    
    
    private IEnumerator AnimateFill(Image img, float target, float duration)
    {
        
        float time = 0f;
        float start = img.fillAmount;

        while (time < duration)
        {
            
            time += Time.deltaTime;
            float t = time / duration;
            t = t * t * (3f - 2f * t); // smoothstep

            img.fillAmount = Mathf.Lerp(start, target, t);

            yield return null;
        }

        img.fillAmount = target;
    }
}
