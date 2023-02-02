using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private Vector3 spawnArea;
    [SerializeField] private float minSpawnInterval = 3f;
    [SerializeField] private float maxSpawnInterval = 6f;

    private float timeToNextSpawn;

    
    private void EnemySpawner()
    {
        if(Time.time >= timeToNextSpawn)
        {
            Vector3 randomSpawnPos = new Vector3(
                transform.position.x + Random.Range(-spawnArea.x, spawnArea.x),
                transform.position.y + 2,
                transform.position.z + Random.Range(-spawnArea.z, spawnArea.z));

            Instantiate(enemyToSpawn, randomSpawnPos, Quaternion.identity);

            timeToNextSpawn = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }


    private void Start()
    {
        timeToNextSpawn = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    // Update is called once per frame
    private void Update()
    {
        EnemySpawner();
    }
}
