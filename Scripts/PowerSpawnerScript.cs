using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawnerScript : MonoBehaviour
{
    public Transform[] powerSpawnPoints;
    public GameObject healthPrefab;
    public GameObject twoXPrefab;
    public GameObject firePrefab;
    public float waitTime = 0.5f;
    int spawnTime = 25;
    void Update()
    {
        spawnTime += (int)(Time.deltaTime % 60);
        if (spawnTime == 25)
        {
            SpawnPowerUps();
            StartCoroutine(Wait());
        }
    }
    void SpawnPowerUps()
    {
        
        
               int spawnIndex = Random.Range(0, powerSpawnPoints.Length);
            Instantiate(healthPrefab, powerSpawnPoints[spawnIndex].position, Quaternion.identity);
        spawnTime = 0;
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
    }
}
