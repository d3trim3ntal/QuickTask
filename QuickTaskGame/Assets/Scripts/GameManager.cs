using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public float spawnInterval  = 0.5f;
    public float xRange = 5f;
    public float yStart = 0f;
    public float yRange = 10f;

    private float nextSpawnTime;
    private float lastSpawnY;
  

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time;
        lastSpawnY = yStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnPlatform();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnPlatform()
    {
        float x = Random.Range(-xRange, xRange);
        float y = lastSpawnY + Random.Range(0.5f, yRange);
        lastSpawnY = y;

        Vector3 spawnPosition = new Vector3(x, y, -9.82f);
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }
}
