using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_2Script : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] powerUPsPrefab;
    public GameObject[] enemyPrefab;
    public float timeToSpawn = 1f;
    public float timeBetweenWaves = 2f;
    public float waitForTime = 0.5f;

    void FixedUpdate()
    {
        if (Time.time >= timeToSpawn)
        {

            SpawnEnemy();
            timeToSpawn = Time.time + timeBetweenWaves;
            timeBetweenWaves -= 0.0001f;
            if (timeBetweenWaves <= 1.554f)
            {
                waitForTime -= 0.05f;
            }
        }
    }
    void SpawnEnemy()
    {
        int j = Random.Range(0, enemyPrefab.Length);
        int randomIndex = Random.Range(0, spawnPoints.Length);
        int randomPos = Random.Range(0, 2);
        if (randomPos == 1)
        {
            for (int i = 0; i<spawnPoints.Length; i+=2)
            {
                if (randomIndex != i)
                {
                    Instantiate(enemyPrefab[j], spawnPoints[i].position, Quaternion.identity);
                     StartCoroutine(Wait());
}
                else
                {
                    if (i<5)
                    {
                        int index = Random.Range(0, powerUPsPrefab.Length);
                        powerUPsPrefab[index].GetComponent<Rigidbody2D>().gravityScale = 0;
                        Instantiate(powerUPsPrefab[index], spawnPoints[i].position, Quaternion.identity);
                        StartCoroutine(Wait());
                        powerUPsPrefab[index].GetComponent<Rigidbody2D>().gravityScale = 1;
                    }

                }
            }
        }
        else
        {
            for (int i = 1; i<spawnPoints.Length; i+=2)
            {
                if (randomIndex != i)
                {
                    Instantiate(enemyPrefab[j], spawnPoints[i].position, Quaternion.identity);
                    StartCoroutine(Wait());
                }
                else
                {
                    if (i<5)
                    {
                        int index = Random.Range(0, powerUPsPrefab.Length);
                        powerUPsPrefab[index].GetComponent<Rigidbody2D>().gravityScale = 0f;
                        Instantiate(powerUPsPrefab[index], spawnPoints[i].position, Quaternion.identity);
                        StartCoroutine(Wait());
                        powerUPsPrefab[index].GetComponent<Rigidbody2D>().gravityScale = 1;
                    }

                }
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitForTime);
    }
}
