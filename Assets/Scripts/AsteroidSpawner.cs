using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefabs; // Asteroid prefabs array
    public float spawnRate = 1f; // Spawn rate in seconds
    public float spawnRadius = 10f; // Radius around the spawner where asteroids can appear
    public float minDistance = 2f; // Minimum distance between asteroids

    private List<GameObject> spawnedAsteroids = new List<GameObject>(); // List to keep track of spawned asteroids

    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            SpawnAsteroid();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void SpawnAsteroid()
    {
        Vector3 spawnPosition;
        bool validPosition = false;
        int attempts = 0;

        // Attempt to find a valid spawn position
        do
        {
            // Choose a random position within the spawn radius
            spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            spawnPosition.z = 0; // Ensure the asteroid spawns on the same z plane

            // Check if the position is valid
            validPosition = true;
            foreach (GameObject asteroid in spawnedAsteroids)
            {
                if (Vector3.Distance(spawnPosition, asteroid.transform.position) < minDistance)
                {
                    validPosition = false;
                    break;
                }
            }

            attempts++;
            if (attempts > 100)
            {
                // Break the loop if too many attempts have been made
                validPosition = true;
            }

        } while (!validPosition);

        // Choose a random asteroid prefab
        int index = Random.Range(0, asteroidPrefabs.Length);
        GameObject asteroidPrefab = asteroidPrefabs[index];

        // Instantiate the asteroid
        GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        spawnedAsteroids.Add(newAsteroid);
    }
}
