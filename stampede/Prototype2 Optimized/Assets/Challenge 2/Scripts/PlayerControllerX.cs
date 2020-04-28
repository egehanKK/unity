using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float SpawnRate = 0.5f;
    private float DelayTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > DelayTimer)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            DelayTimer = Time.time + SpawnRate;
        }
    }

}
