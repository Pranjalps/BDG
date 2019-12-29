using UnityEngine;
using System.Collections;

public class BlockSpawnewrScript : MonoBehaviour {
    public Transform[] spawnPoints;
        public GameObject blockPrefab;
    public GameObject[] powerUPsPrefab;
    public float timeToSpawn = 2f;
    public float timeBetweenWaves = 1.9999f;
    public float waitForTime = 0.2f;
    //public int powerUpSpawnRandom = 5;
    
	// Use this for initialization
	void FixedUpdate () {
        if (Time.time >= timeToSpawn)
        {

            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
            timeBetweenWaves -= 0.0001f;
            if (timeBetweenWaves <= 1.95f)
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
                    Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
                    StartCoroutine(Wait());
                }
                else
                {
                    if (i < 5)
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
                    Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
                    StartCoroutine(Wait());
                }
                else
                {

                    if (i > 2)
                    {
                        int index = Random.Range(0, powerUPsPrefab.Length);
                        Instantiate(powerUPsPrefab[index], spawnPoints[i].position, Quaternion.identity);
                        StartCoroutine(Wait());
                    }

                }
            }
        }
        /*else
        {
            for (int i = 0; i < spawnPoints.Length; i += 3)
            {
                if (randomIndex != i||randomIndex!=i+2)
                {
                    Instantiate(blockprefab, spawnPoints[i].position, Quaternion.identity);
                    StartCoroutine(Wait());
                }
                else
                {
                    if (powerUpIndex >= 0)
                    {
                        int index = Random.Range(0, 3);
                        Instantiate(powerUPsPrefab[index], spawnPoints[i].position, Quaternion.identity);
                        StartCoroutine(Wait());
                    }

                }
            }
        }*/
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitForTime);
    }
	
}
