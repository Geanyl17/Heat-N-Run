using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxHealth(int currentHealth)
    {
        slider.maxValue = currentHealth;
        slider.value = currentHealth;
    }
    // Start is called before the first frame update
    public void SetHealth(int currentHealth)
    {
        slider.value = currentHealth;
    }
}
