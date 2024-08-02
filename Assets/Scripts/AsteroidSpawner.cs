using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefabs; // Asteroid prefabs array
    public float spawnRate = 1f; // Spawn rate in seconds
    public float spawnRadius = 10f; // Radius around the spawner where asteroids can appear
    public float minDistance = 2f; // Minimum distance between asteroids
    public GameObject levelManager;
    private int level;
    private List<GameObject> spawnedAsteroids = new List<GameObject>(); // List to keep track of spawned asteroids

    void Start()
    {
        StartCoroutine(SpawnAsteroids());
        levelManager = GameObject.Find("LevelManager");
    }

    void Update()
    {
        level = levelManager.GetComponent<LevelManager>().GetLevel();
        CleanupAsteroidsList(); // Remove null references from the list
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
                if (asteroid != null && Vector3.Distance(spawnPosition, asteroid.transform.position) < minDistance)
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

        // Choose a random asteroid prefab with a weighted chance
        int maxIndex = Mathf.Min(level / 3, asteroidPrefabs.Length - 1);
        int index = GetWeightedRandomIndex(maxIndex);

        GameObject asteroidPrefab = asteroidPrefabs[index];

        // Instantiate the asteroid
        GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        spawnedAsteroids.Add(newAsteroid);
    }

    int GetWeightedRandomIndex(int maxIndex)
    {
        int[] weights = new int[maxIndex + 1];
        for (int i = 0; i < maxIndex; i++)
        {
            weights[i] = 1; // default weight
        }
        weights[maxIndex] = 9; // increased weight for the latest type

        int totalWeight = 0;
        for (int i = 0; i <= maxIndex; i++)
        {
            totalWeight += weights[i];
        }

        int randomWeight = Random.Range(0, totalWeight);
        for (int i = 0; i <= maxIndex; i++)
        {
            if (randomWeight < weights[i])
            {
                return i;
            }
            randomWeight -= weights[i];
        }

        return maxIndex; // Fallback in case of an error
    }

    void CleanupAsteroidsList()
    {
        // Remove null references from the list
        spawnedAsteroids.RemoveAll(asteroid => asteroid == null);
    }
}
