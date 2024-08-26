using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatRand : MonoBehaviour
{
    public GameObject[] platforms;
    public Transform player;
    public float spawnDelay = 1f;
    public float heightIncrement = 2f;

    private bool isSpawning = false;
    private float currentHeight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlatform();
    }

    // Update is called once per frame
    void SpawnPlatform()
    {
        int randomPlatformIndex = Random.Range(0, platforms.Length);
        int randomXPosition = Random.Range(-2, 2);

        Vector3 spawnPosition = new Vector3(randomXPosition, currentHeight, -9.5f);
        Instantiate(platforms[randomPlatformIndex], spawnPosition, Quaternion.identity);
        currentHeight += heightIncrement;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isSpawning)
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
