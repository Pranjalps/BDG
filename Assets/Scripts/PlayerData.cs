using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class PlayerData 
{
   // public float score;
    public float player1Speed;
    public float player2Speed;
    public float player3Speed;
    public float playerSurvivalSpeed;
    public bool trigger;
   // public Text name1;
    public float volume;

    public PlayerData(MainMenu player)
    {
        player1Speed = player.level1Speed;
        player2Speed = player.level2Speed;
        player3Speed = player.level3Speed;
        playerSurvivalSpeed = player.survivalSpeed;
        trigger = player.trigger1;
      //  name1.text = player.name2.text;
        volume = player.volume1;
    }

}
