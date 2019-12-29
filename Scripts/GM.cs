using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GM : MonoBehaviour
{
    
    private int lives ;
    public float slowness = 10f;
    public Text Score;
    float score1=0f;
    float score2;
    public Text Lives;
    public Text level;
    bool gameHasEnded = false;
   // float gravityScale;
    //int factor;
    //public int rangeParameter = 8;

    float maxScore;
    float score;
  
    
    public void EndGame()
    {
        if (!gameHasEnded)
        {
            if (lives >= 1)
            { //FindObjectOfType<EnemyHealthScript>().Die();
                lives -= 1;
                PlayerPrefs.SetFloat("PlayerScore", score2);
               
                StartCoroutine(Slow());

            }
            else
            {
                //FindObjectOfType<EnemyHealthScript>().Die();
                gameHasEnded = true;
                Debug.Log("Game Over");

                if (score2 > maxScore)
                {
                    maxScore = score2;
                }
                PlayerPrefs.SetFloat("PlayerScore", score2);
                PlayerPrefs.SetFloat("PlayerMaxScore", maxScore);
                Debug.Log("The Score is:" + maxScore);

                StartCoroutine(Slow());
                GameOver();
            }
        }
    }

    IEnumerator Slow()
    {    
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        yield return new WaitForSeconds(1f / slowness);
        
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        
    }
    void GameOver()
    {

        SceneManager.LoadScene("GameOver");
    }
    /*void Awake()
    {
       DontDestroyOnLoad(gameObject);
     //   DontDestroyOnLoad(GameObject.Find("Score"));
       DontDestroyOnLoad(GameObject.Find("Canvas"));

    }*/
   void Start()
    {
        level.text = SceneManager.GetActiveScene().buildIndex.ToString();

        lives = PlayerPrefs.GetInt("PlayerCurrentLives",3);
        score = PlayerPrefs.GetFloat("PlayerScore");
        maxScore = PlayerPrefs.GetFloat("PlayerMaxScore",0f);
        Time.timeScale = 1f;
    }
    void Update()
    {
        // rangeParameter = Random.Range(4, 8);
        if (SceneManager.GetActiveScene().buildIndex <=3)
        {
            score1 = Mathf.Round(Time.timeSinceLevelLoad);
            score2 = score + score1;
            Score.text = score2.ToString();
            Lives.text = lives.ToString();
            if (score1 == 50)
            {

                PlayerPrefs.SetInt("PlayerCurrentLives", lives);
                PlayerPrefs.SetFloat("PlayerScore", score2);
                StartCoroutine(Slow());
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
        }
        else
        {
            score2 = score + score1;
            Score.text = score2.ToString(); ;
            Lives.text = lives.ToString();
            if (score2 % 1000 == 0)
            {
                int i = (int)score2 / 1000;
                FindObjectOfType<Weapon>().PlayerChanger(i);
            }
        }
    }
    public float GetMaxScore()
    {
        return maxScore;
    }

    public void Twox()
    {
        score += 10;
        Debug.Log("Twox pOWERuP");
    }
    /* public float GravityScale()
     {
         factor = Random.Range(1, rangeParameter);
         gravityScale = 1f / factor;
         return gravityScale;

     }*/

    public void ScoreValueUpdate()
    {
        score1 += 1; 
    }
    public void HealthPowerUp()
    {
        lives += 1;

    }
}
