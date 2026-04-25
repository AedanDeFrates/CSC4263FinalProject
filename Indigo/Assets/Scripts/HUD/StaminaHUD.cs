using UnityEngine;
using UnityEngine.UI;

public class StaminaHUD : MonoBehaviour
{
    public PlayerStamina stamina;
    public Slider staminaSlider;

    void Start()
    {
        UpdateStamina((float)stamina.currentStamina, (float)stamina.maxStamina);
        stamina.OnStaminaChanged += UpdateStamina;
    }

    void UpdateStamina(float current, float max)
    {
        staminaSlider.value = current / max;
    }
}
