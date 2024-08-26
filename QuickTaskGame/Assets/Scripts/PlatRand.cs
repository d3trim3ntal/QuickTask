using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatRand : MonoBehaviour
{
    public GameObject[] platforms;
    public GameObject ball;
    public Transform player;
    public float spawnDelay = 1f;
    public float heightIncrement = 1.5f;

    private bool isSpawning = true;
    private float currentHeight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlatform();
    }

    // Update is called once per frame
    void SpawnPlatform()
    {
        int randomPlatformIndex = Random.Range(2, platforms.Length);
        int randomXPosition = Random.Range(-2, 2);

        Vector3 spawnPosition = new Vector3(randomXPosition, currentHeight, -9.5f);
        Instantiate(platforms[randomPlatformIndex], spawnPosition, Quaternion.identity);
        currentHeight += heightIncrement;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == ball)
        {
            StartCoroutine(SpawnPlatformsContinuously());
            Debug.Log("Player has collided with " + collision.gameObject.name);
        }
    }

    IEnumerator SpawnPlatformsContinuously()
    {
        isSpawning = true;
        while (true)
        {
            SpawnPlatform();
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
