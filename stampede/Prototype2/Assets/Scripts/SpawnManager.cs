using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    public GameObject[] animalPrefabs;
    public float spawnRangeX = 15;
    public float spawnPosZ = 20;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimals", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {



    }

    void SpawnRandomAnimals()
    {

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnLocation = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnLocation, animalPrefabs[animalIndex].transform.rotation);

    }
}
