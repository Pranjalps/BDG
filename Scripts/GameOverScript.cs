using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI _name;
  public TextMeshProUGUI playerName;
    /*void Start()
    {
        name = gameObject.GetComponent<TextMeshProUGUI>();
    }*/
   public void EndText()
    {
        playerName.text =_name.text;
        Debug.Log(playerName.text);
    }
   
}
