using System.Diagnostics.Contracts;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] listOfEnemySpawner;

    public float interval;
    int index = 1;
    float timer;

    // Update is called once per frame
    void Update()
    {
        if (index >= listOfEnemySpawner.Length) return;

        timer += Time.deltaTime;
        
        if(timer >= interval)
        {
            listOfEnemySpawner[index++].SetActive(true);
            timer = 0f;
        }
    }
}
