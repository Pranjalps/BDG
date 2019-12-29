using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel_02 : MonoBehaviour {
    public float speed = 15f;
   public float mapWidth=15f;
    public bool hit = false;
    float waitForTime = 0.5f;
    float powerUpTime = 2f;
    public float accelerationSpeed = 60f;
    public bool trigger = false;
    // int lives;
    //float gravityScale;
    //int factor;
    //  public int rangeParameter = 4;
    Rigidbody2D rb;
    void Start()
    {
   
        Time.timeScale = 1f;
        //lives = PlayerPrefs.GetInt("PlayerCurrentLives");
        accelerationSpeed = PlayerPrefs.GetFloat("PlayerLevel2Speed",65f);
        rb = GetComponent<Rigidbody2D>();
    }
	void FixedUpdate()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        //  rangeParameter = Random.Range(2, 8);
        //lives = PlayerPrefs.GetInt("PlayerCurrentLives");
        float x = Input.GetAxis("Horizontal")*Time.fixedDeltaTime*speed;
        Vector2 newPosition = rb.position + Vector2.right * x;
        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        rb.MovePosition(newPosition);

#endif     
        if (hit)
        {
            StartCoroutine(Wait());
            hit = false;
        }
#if UNITY_ANDROID
        if (trigger)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.y = 0;
                touchPosition.z = 0;
                touchPosition.x = Mathf.Clamp(touchPosition.x, -mapWidth, mapWidth);
                transform.position = touchPosition;

            }
        }
        else
        {
            Vector3 acc = Vector3.zero;
            acc.x = Input.acceleration.x;
            // acc.z = Input.acceleration.x;

            /*
            newPosition1.x = Mathf.Clamp(newPosition1.x, -mapWidth, mapWidth);
            newPosition1.y = Mathf.Clamp(newPosition1.y, -mapHight, mapHight);*/

            if (acc.sqrMagnitude > 1)
            {
                acc.Normalize();
            }
            acc.x *= Time.deltaTime;

            transform.Translate(acc * accelerationSpeed);
        }
#endif
    }
    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Enemy")
        {
           
            if (!hit)
            {
                FindObjectOfType<GM>().EndGame();

                hit = true;
            }
        }
        if (obj.gameObject.tag == "Health")
        {
            obj.gameObject.GetComponent<Health>().Die();
            FindObjectOfType<GM>().HealthPowerUp();
        }
        if (obj.gameObject.tag == "TwoX")
        {
            FindObjectOfType<GM>().Twox();
            obj.gameObject.GetComponent<TwoX>().Die();
           
        }
    }
    public void AdjustPlayerSpeed(float newSpeed)
    {
        accelerationSpeed = newSpeed;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitForTime);
    }
    IEnumerator PowerUPTime()
    {
        yield return new WaitForSeconds(powerUpTime);
    }
    /*  public float GravityScale()
     {
         factor = Random.Range(1, rangeParameter);
         gravityScale = 1f / factor*Time.fixedDeltaTime;
         return gravityScale;

     }*/
    public void GetTriggerInverse(bool trigger1)
    {
        trigger = trigger1;
    }
}
