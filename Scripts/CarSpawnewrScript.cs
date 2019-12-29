using UnityEngine;
using System.Collections;

public class CarSpawnewrScript : MonoBehaviour {
    public Transform[] spawnPoints;
        public GameObject carPrefab;
    public GameObject[] powerUPsPrefab;
    public float timeToSpawn = 2f;
    [Range(1,2)]
    public float timeBetweenWaves = 1.9999f;
    [Range(0,1)]
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
        int randomPos = Random.Range(0, 3);
        if (randomPos == 1)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (randomIndex != i)
                {
                    Instantiate(carPrefab, spawnPoints[i].position, Quaternion.identity);
                    StartCoroutine(Wait());
                }
                else
                {
                    if (i<2)
                    {

                        int index = Random.Range(0, powerUPsPrefab.Length);
                        Instantiate(powerUPsPrefab[index], spawnPoints[i].position, Quaternion.identity);
                        StartCoroutine(Wait());
                    }

                }
            }
        }
        else if(randomPos==2)
        {
            for (int i = 1; i < spawnPoints.Length; i+=2)
            {
                if (randomIndex == i)
                {
                    Instantiate(carPrefab, spawnPoints[i].position, Quaternion.identity);
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
         else
        {
            for (int i = 1; i < spawnPoints.Length; i += 2)
            {
                //if (randomIndex != i)
              //  {
                    Instantiate(carPrefab, spawnPoints[i].position, Quaternion.identity);
                    StartCoroutine(Wait());
               // }
                //else
                //{

                    if (i > 2)
                    {
                        int index = Random.Range(0, powerUPsPrefab.Length);
                        Instantiate(powerUPsPrefab[index], spawnPoints[i].position, Quaternion.identity);
                        StartCoroutine(Wait());
                    }

                //}
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
