using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSleep : MonoBehaviour, IFriendlyDamagable
{
    [SerializeField] Slider sleepDisplay;
    [SerializeField] float maxHealth, delta;
    float currentHealth, displayHealth = 0;

    void Start()
    {
        currentHealth = maxHealth;
        sleepDisplay.maxValue = maxHealth;
    }

    void Update()
    {
        if (currentHealth < 0) currentHealth = 0;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        displayHealth = Mathf.Lerp(displayHealth, currentHealth, delta);
        sleepDisplay.value = displayHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
