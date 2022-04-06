using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruits : MonoBehaviour
{
    public GameObject obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;
    public float MinTimeBetweenSpawn;

    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            if(timeBetweenSpawn>MinTimeBetweenSpawn)
            {
                timeBetweenSpawn -= 0.1f * Time.deltaTime; 
            }
            spawnTime = Time.time + timeBetweenSpawn;

        }
        
    }
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 20), transform.rotation);
    }
}
