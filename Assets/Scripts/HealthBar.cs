using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient; //allows for gradient of colors for diff points in hp
    public Image fill;

    //this sets the hp bar
    public void setHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    //this allows you to modify max HP from script instead of toolbar
    public void setMaxHealth(int health)

    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
}
   

  
