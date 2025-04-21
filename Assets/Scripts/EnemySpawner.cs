using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemy;
    public float spawnDelay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null) StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        Spawn();
        yield return new WaitForSeconds(spawnDelay);
    }

    void Spawn()
    {
        GameObject spawnedEnemy = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
        GameObject c = GameObject.Find("PlaceholderHealthBar_Enemy");

        spawnedEnemy.GetComponent<HealthSystem>().healthbarUI = c.GetComponent<Slider>();

        int randSortNum = UnityEngine.Random.Range(1000, 1);
        spawnedEnemy.GetComponent<SpriteRenderer>().sortingOrder = randSortNum;

        int randSpeedNum = UnityEngine.Random.Range(5, 3);
        spawnedEnemy.GetComponent<FollowPlayer>().movementSpeed = randSpeedNum;

        enemy = spawnedEnemy;
    }
}
