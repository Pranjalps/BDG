using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    private int playerLives = 3;
    private float score = 0f;
    void Start()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
        PlayerPrefs.SetFloat("PlayerScore", score);
    }
    public void LoadPlayScene(int num)
    {
        SceneManager.LoadScene(num);
    }
}
