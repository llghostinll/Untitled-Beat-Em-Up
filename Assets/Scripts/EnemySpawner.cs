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

        int randSortNum = UnityEngine.Random.Range(1000, 1);
        spawnedEnemy.GetComponent<SpriteRenderer>().sortingOrder = randSortNum;

        int randSpeedNum = UnityEngine.Random.Range(5, 3);
        spawnedEnemy.GetComponent<FollowPlayer>().movementSpeed = randSpeedNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
