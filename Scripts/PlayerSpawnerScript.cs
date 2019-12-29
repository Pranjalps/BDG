using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerScript : MonoBehaviour
{
    public GameObject playerPrefab;
  //  public GameObject deathPrefab;
    public void Respwan()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
