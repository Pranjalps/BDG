using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {
    public Transform[] spawnPoints;
    public GameObject[] powerUPsPrefab;
    public GameObject enemyprefab;
    public float timeToSpawn = 1f;
    public float timeBetweenWaves = 1.5555f;
    public float waitForTime = 0.2f;
   // public int powerUpSpawnRandom = 5;
    // Use this for initialization
    void FixedUpdate () {
        if (Time.time >= timeToSpawn)
        {

            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
            timeBetweenWaves -= 0.0001f;
            if (timeBetweenWaves <= 1.554f)
            {
                waitForTime -= 0.05f;
            }
        }
                   }
    
	void SpawnBlocks()
    {
       // int powerUpIndex = Random.Range(0, powerUpSpawnRandom);
        int randomIndex = Random.Range(0, spawnPoints.Length);
       // powerUpSpawnRandom = randomIndex;
        int randomPos = Random.Range(0, 2);
        if (randomPos == 1)
        {
            for (int i = 0; i < spawnPoints.Length; i+=2)
            {
                if (randomIndex != i)
                {
                    Instantiate(enemyprefab, spawnPoints[i].position, Quaternion.identity);
                    StartCoroutine(Wait());
                }
                else
                {
                    if (i<5)
                    {
                        int index = Random.Range(0, powerUPsPrefab.Length);
                        Instantiate(powerUPsPrefab[index], spawnPoints[i].position, Quaternion.identity);
                        StartCoroutine(Wait());
                    }

                }
            }
        }
        else
        {
            for (int i = 1; i < spawnPoints.Length; i+=2)
            {
                if (randomIndex != i)
                {
                    Instantiate(enemyprefab, spawnPoints[i].position, Quaternion.identity);
                    StartCoroutine(Wait());
                }
                else
                {
                    if (i<5)
                    {
                        int index = Random.Range(0, powerUPsPrefab.Length);
                        Instantiate(powerUPsPrefab[index], spawnPoints[i].position, Quaternion.identity);
                        StartCoroutine(Wait());
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
