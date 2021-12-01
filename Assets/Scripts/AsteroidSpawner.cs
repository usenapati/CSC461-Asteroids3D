using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidObjects;

    public int amountAsteroidsToSpwan;

    public float minRandomSpawn = -500;
    public float maxRandomSpawn = 500;

    private void Start()
    {
        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
        for (int i = 0; i < amountAsteroidsToSpwan; i++)
        {
            float randomX = UnityEngine.Random.Range(minRandomSpawn, maxRandomSpawn);
            float randomY = UnityEngine.Random.Range(minRandomSpawn, maxRandomSpawn);
            float randomZ = UnityEngine.Random.Range(minRandomSpawn, maxRandomSpawn);
            Vector3 randomSpawnPoint = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z + randomZ);

            GameObject tempObj = Instantiate(asteroidObjects[0], randomSpawnPoint, Quaternion.identity);
            tempObj.transform.parent = this.transform;
        }
    }

    public void SpawnAsteroid(Vector3 position, int size)
    {
        int randSize;
        //LARGE
        if (size == 2)
        {
            randSize = UnityEngine.Random.Range(0, 3);
        }
        //MEDIUM
        else if (size == 1)
        {
            randSize = UnityEngine.Random.Range(3, 6);
        }
        //SMALL
        else
        {
            randSize = UnityEngine.Random.Range(6, 9);
        }
        GameObject tempObj = Instantiate(asteroidObjects[randSize], position, Quaternion.identity);
        tempObj.transform.parent = this.transform;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(maxRandomSpawn * 2, maxRandomSpawn * 2, maxRandomSpawn * 2));
    }
}