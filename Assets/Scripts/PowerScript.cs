using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    private int lives;
   public void HealthUp()
    {
        if (lives < 3)
        {
            lives += 1;
        }
        PlayerPrefs.SetInt("PlayerCurrentLives",lives);
    }
    // Start is called before the first frame update
    void Start()
    {
        lives = PlayerPrefs.GetInt("PlayerCurrentLives");
    }

    // Update is called once per frame
    void Update()
    {
        HealthUp();
    }
}
