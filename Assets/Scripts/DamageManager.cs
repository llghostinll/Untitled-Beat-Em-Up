using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class DamageManager : MonoBehaviour
{
    public HealthSystem healthSystem;
    public CombatSystem combatSystem;
    private SpriteRenderer sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        // combatSystem = GetComponent<CombatSystem>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");

        switch (collision.gameObject.tag)
        {

            case "Punch":
                DamageAction(3.0f);
                break;
            case "Kick":
                DamageAction(5.0f);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Detected");

        switch (collision.gameObject.tag)
        {

            case "Punch":
                StartCoroutine(DamageAction(3.0f));
                break;
            case "Kick":
                StartCoroutine(DamageAction(5.0f));
                break;
        }
    }

    IEnumerator DamageAction(float damageTaken)
    {
        Debug.Log("Enemy Hit");
        healthSystem.DecereaseHealth(damageTaken);
        sprite.color = Color.red;
        yield return new WaitForSeconds(.5f);
        sprite.color = Color.white;
    }
}
