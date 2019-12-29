using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region singelton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;


   /* public void GameOverPlayer(GameObject obj)
    {
        
      // Destroy(obj.gameObject);
        SceneManager.LoadScene("GameOver");

    }*/
}
