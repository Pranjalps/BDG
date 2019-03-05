using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;


public class MainMenu : MonoBehaviour
{/// <summary>
/// variable declaration and initialization for MainMenu and Game 
/// </summary>
   public PlayerOriginal pO;
    public PlayerLevel_02 p2;
    public PlayerLevel4 p4;
    public Player03ControllerScript su;
    public AudioMixer audioMixer;
    private int playerLives = 3;
    private float score = 0f;
    public float level1Speed = 30f;
   public float level2Speed = 65f;
    public float level3Speed = 30f;
    public float survivalSpeed = 10f;
    public Slider su1;
    public Slider pO1;
    public Slider p21;
    public Slider P41;
    public Toggle trigger;
    public bool trigger1;
    public float volume1;

    public TextMeshProUGUI name1;
    public TextMeshProUGUI playerName;
   // public Text name2;


    private void Start()
    {
        /*pO = FindObjectOfType<PlayerOriginal>();
        p2 = FindObjectOfType<PlayerLevel_02>();
        su = FindObjectOfType<Player03ControllerScript>();*/
        

    }
    private void Update()
    {
        /* SetLevel1Speed(level1Speed);
         SetLevel2Speed(level2Speed);
         SetSurvivalSpeed(survivalSpeed);*/
        trigger1 = trigger.isOn;          //set trigger value
        su.GetTriggerInverse(trigger1); //call the function of script sitting on survival's player 
        p2.GetTriggerInverse(trigger1); //call the function of script sitting on level 2 player
        pO.GetTriggerInverse(trigger1); //call the function of script sitting on level 1 player
        p4.GetTriggerInverse(trigger1); //call the function of script sitting on level 3 player
    }
    public void PlayGame()
    {
        Debug.Log("Game started");   //Log the value That Game Has Started
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load The First Scene
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);//Set Player Lifes in PlayerCurrentLives
        PlayerPrefs.SetFloat("PlayerScore", score);//Set The Score To PlayerScore
    }

    //Set AudioMixer Volume According To Slider
    public void SetVolume(float volume)
    {
        volume1 = volume;
        audioMixer.SetFloat("volume", volume);
    }


    //Quit The Application If Player Presses Quit Button
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    //Set Speed Of Player Of Survival
    public void SetSurvivalSpeed(float speed=15f)
    {
        //  FindObjectOfType<Player03ControllerScript>().AdjustPlayerSpeed(speed);
        // su.AdjustPlayerSpeed(speed);
        survivalSpeed = speed;
        PlayerPrefs.SetFloat("PlayerSurvivalSpeed", survivalSpeed);//set speed to playerprefs
        su1.value = speed;
    }
    //Set Speed Of Player Of Level1
    public void SetLevel1Speed(float speed=35f)
    {
        //FindObjectOfType<PlayerOriginal>().AdjustPlayerSpeed(speed);
        // pO.AdjustPlayerSpeed(speed);
        level1Speed = speed;
        PlayerPrefs.SetFloat("PlayerLevel1Speed", level1Speed);//set speed to playerprefs
        pO1.value = speed;
    }
    //Set Speed Of Player Of Level2
    public void SetLevel2Speed(float speed=65f)
    {
        //  FindObjectOfType<PlayerLevel_02>().AdjustPlayerSpeed(speed);
        //  p2.AdjustPlayerSpeed(speed);
        level2Speed = speed;
        PlayerPrefs.SetFloat("PlayerLevel2Speed", level2Speed);//set speed to playerprefs
        p21.value = speed;
    }
    public void SetLevel3Speed(float speed = 35f)
    {
        //  FindObjectOfType<PlayerLevel_02>().AdjustPlayerSpeed(speed);
        //  p2.AdjustPlayerSpeed(speed);
        level3Speed = speed;
        PlayerPrefs.SetFloat("PlayerLevel3Speed", level3Speed);//set speed to playerprefs
        P41.value = speed;
    }
    public void EndText()
    {
        playerName.text = name1.text;
        //name2.text = name1.text;
        Debug.Log(playerName.text);
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        Debug.Log("SavePlayer Called");
    }
    public void LoadPlayer()
    {
        Debug.Log("LoadPlayerCalled");
        PlayerData data = SaveSystem.LoadPlayer();

        level1Speed = data.player1Speed;
        level2Speed = data.player2Speed;
        survivalSpeed = data.playerSurvivalSpeed;
        trigger1 = data.trigger;
       // name1.text = data.name1.text;
        volume1 = data.volume;
    } 
}

