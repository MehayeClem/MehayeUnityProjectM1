using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        //gradient est un dégradé de couleur. 1f = 100% du dégradé
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        //le normalized sert juste a normaliser les valeurs du slider pour le grandient
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
