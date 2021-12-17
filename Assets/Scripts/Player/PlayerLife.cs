using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth   = maxHealth;
        slider.maxValue = maxHealth;
        slider.value    = currentHealth;
    }

    void changeHealth(float delta)
    {
        if (currentHealth + delta <= maxHealth && currentHealth + delta >= 0)
        {
            currentHealth += delta;
            slider.value = currentHealth;
        }
        else if (currentHealth + delta > maxHealth) {
            currentHealth = maxHealth;
        }
        else {
            currentHealth = 0;
        }
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }

    public void setCurrentHealth(float newVal)
    {
        currentHealth = newVal;
        slider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Numpad+-"))
        {
            changeHealth(Input.GetAxis("Numpad+-") * 10);
        }
    }
}
