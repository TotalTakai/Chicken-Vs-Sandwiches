using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalsPrefab;

    // Info needed for animals spawning
    public float SpawnPositionZ = 20.0f;
    private float spawnRangeX = 14.0f;
    private float spawnRangeZLow = -1.0f;
    private float spawnRangeZHigh = 16.0f;
    private float startDelay = 2.0f;
    private float SpawnInterval = 0.5f;

    private string[] directions = { "top", "left", "right" };


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, SpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Controls The spawning of enemies from the top of the map
    void SpawnRandomAnimal()
    {

        int animalIndex = Random.Range(0, animalsPrefab.Length);
        string spawnDirection = directions[Random.Range(0, directions.Length)];
        Vector3 spawnPosition = Vector3.zero;
        Quaternion rotation = new Quaternion();

        switch (spawnDirection)
        {
            case "left":
                spawnPosition = new Vector3(-30, 0, Random.Range(spawnRangeZLow, spawnRangeZHigh));
                rotation = Quaternion.LookRotation(Vector3.right);
                break;
            case "right":
                spawnPosition = new Vector3(30, 0, Random.Range(spawnRangeZLow, spawnRangeZHigh));
                rotation = Quaternion.LookRotation(Vector3.left);
                break;
            default:
                spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, SpawnPositionZ);
                rotation = animalsPrefab[animalIndex].transform.rotation;
                break;
        }
        Instantiate(animalsPrefab[animalIndex], spawnPosition, rotation);
    }
}