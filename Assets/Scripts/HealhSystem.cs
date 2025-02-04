using System;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HealhSystem : MonoBehaviour
{
    public float currentHealth;
    [SerializeField]
    private float maxHealth = 100.0f;
    public Slider healthbar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentHealth = maxHealth;
        healthbar.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public void DecereaseHealth(float damage)
    {
        float remainingHealth = currentHealth - damage;

        if (remainingHealth < 0)
        {
            currentHealth = 0;
            healthbar.value = currentHealth;
            return;
        }

        currentHealth = remainingHealth;
        healthbar.value = currentHealth;
        Debug.Log(string.Format("Player has {0} remaining", currentHealth));
    }

    public void IncreaseHealth(float amount)
    {
        float healedHealth = currentHealth + amount;

        if (healedHealth > maxHealth)
        {
            currentHealth = maxHealth;
            healthbar.value = currentHealth;
            return;
        }

        currentHealth = healedHealth;
        healthbar.value = currentHealth;
        Debug.Log(string.Format("Player has {0} remaining", currentHealth));
    }
}
