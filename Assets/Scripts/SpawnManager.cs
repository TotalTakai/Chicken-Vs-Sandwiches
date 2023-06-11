using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalsPrefab;
    public float spawnRangeX = 14.0f;
    public float spawnPositionZ = 20.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {

            int animalIndex = Random.Range(0, animalsPrefab.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, 20);
            GameObject spawnedAnimal = animalsPrefab[animalIndex];

            Instantiate(spawnedAnimal, spawnPosition, spawnedAnimal.transform.rotation);
    }
}
