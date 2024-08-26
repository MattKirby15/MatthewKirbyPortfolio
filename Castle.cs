using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] private float currentHealth;

    [SerializeField] Slider HealthSlider;
    
    void Start()
    {
        ///set curent health = maxhealth
        currentHealth = maxHealth;

        ///set health slider max and current values
        HealthSlider.maxValue = maxHealth;
        HealthSlider.value = currentHealth;
    }
    void Update()
    {
        
    }
    public void TakeDamage(float _damageAmount)
    {
        /// subtract amount from current health
        currentHealth -= _damageAmount;

        ///check if health goes below 0
        if (currentHealth <= 0)
        {
            /// consequences
            gameObject.SetActive(false);
        }

        ///set health slider value to current health
        HealthSlider.value = currentHealth;
    }
}
