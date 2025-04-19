using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject spawnedEnemy = Instantiate(enemy, this.transform.position, Quaternion.identity);
        GameObject c = GameObject.Find("PlaceholderHealthBar_Enemy");
        spawnedEnemy.GetComponent<HealthSystem>().healthbarUI = c.GetComponent<Slider>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
