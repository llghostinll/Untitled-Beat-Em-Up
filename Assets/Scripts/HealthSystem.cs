using System;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    private float currentHealth;
    [SerializeField]
    private float maxHealth = 100.0f;
    public Slider healthbarUI;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentHealth = maxHealth;
        healthbarUI.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyUp(KeyCode.B))
        {
            DecereaseHealth(10);
            return;
        }

        if (Input.GetKeyUp(KeyCode.N))
        {
            IncreaseHealth(10);
            return;
        }
        */
    }

    public void DecereaseHealth(float damage)
    {
        float remainingHealth = currentHealth - damage;

        if (remainingHealth < 0)
        {
            currentHealth = 0;
            healthbarUI.value = currentHealth;
            Destroy(this.gameObject);
            return;
        }

        currentHealth = remainingHealth;
        healthbarUI.value = currentHealth;
    }

    public void IncreaseHealth(float amount)
    {
        float healedHealth = currentHealth + amount;

        if (healedHealth > maxHealth)
        {
            currentHealth = maxHealth;
            healthbarUI.value = currentHealth;
            return;
        }

        currentHealth = healedHealth;
        healthbarUI.value = currentHealth;
    }
}
