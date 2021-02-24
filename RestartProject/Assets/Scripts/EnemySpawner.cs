using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    GameObject currentPoint;

    int index;

    public GameObject[] enemies;
    public float minTimeBetweenSpawns;
    public float maxTimeBetweenSpawns;
    public bool canSpawn =true; 
    public float spawnTime;
    public int enemiesInRoom;
    public bool spawnerDone;
    public GameObject spawnerDoneGameObject;
    

    private void Start()
    {
        Invoke ("SpawnEnemy", 0.5f);
    }

    private void Update()
    {
        if (canSpawn) { 
        spawnTime -= Time.deltaTime;
        if(spawnTime < 0)
        {
            canSpawn = false;
        }
        }
    }
    
    void SpawnEnemy()
    {
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
        
        if (canSpawn)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], currentPoint.transform.position, Quaternion.identity);
            enemiesInRoom++;
        }

        Invoke("SpawnEnemy", timeBetweenSpawns);
        if (spawnerDone)
        {
            spawnerDoneGameObject.SetActive(true);
        }
    }




}
