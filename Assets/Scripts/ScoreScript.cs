using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript :MonoBehaviour
{
   
    public Text score;
    public Text maxScore;
    float maxValue;
    float value;
    

    void Start()
    {
        maxValue = PlayerPrefs.GetFloat("PlayerMaxScore", 200f);
        value = PlayerPrefs.GetFloat("PlayerScore",150f);
        maxScore.text = maxValue.ToString();
        score.text = value.ToString();
            
        Debug.Log("The Score inside GameOver:"+value);
        Debug.Log("The MaxScore inside GameOver:" + maxValue);
    }
    
    public void StartMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
   
}
