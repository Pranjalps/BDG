using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel4 : MonoBehaviour {
    public float speed = 15f;
    public float mapWidth=5f;
    public bool hit = false;
    float waitForTime = 0.5f;
    float powerUpTime = 2f;
    public float accelerationSpeed = 10f;
    public Animator anim;
    public AudioClip hitSound;
    AudioSource source;
    public Sprite hitPrefab;
     SpriteRenderer ren;
    public Sprite player;
    public bool trigger = false;
    //float gravityScale;
    //int factor;
    // public int rangeParameter=4;
    //int lives;

    public void AdjustPlayerSpeed(float newSpeed)
    {
        accelerationSpeed = newSpeed;
    }
    Rigidbody2D rb;
    void Start()
    {
        Time.timeScale = 1f;
        //lives = PlayerPrefs.GetInt("PlayerCurrentLives");
        //ToIncrease player movement till screen
        // mapWidth = Screen.width;
        accelerationSpeed = PlayerPrefs.GetFloat("PlayerLevel1Speed",45f);
        rb = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
       ren= GetComponent<SpriteRenderer>();
    }
	void FixedUpdate()
    {
        // hit = false;
        //anim.SetBool("hit", hit);
#if UNITY_EDITOR || UNITY_STANDALONE

        float x = Input.GetAxis("Horizontal")*Time.fixedDeltaTime*speed;
        anim.SetFloat("speed", x);
        if (x > 0) { anim.SetBool("right", true);
        }
        else
        {
            anim.SetBool("right", false);
        }
       // rangeParameter = Random.Range(2, 8);
        Vector2 newPosition = rb.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        rb.MovePosition(newPosition);
        
        
        
       /* if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
           Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.y = 0;
            touchPosition.z = 0;
           transform.Translate(touchPosition);

        }*/
#endif
        if (hit)
        {
            StartCoroutine(Wait());
            hit = false;
            anim.SetBool("hit", hit);
            
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
            //acc.z = Input.acceleration.x;

            /*
            newPosition1.x = Mathf.Clamp(newPosition1.x, -mapWidth, mapWidth);
            newPosition1.y = Mathf.Clamp(newPosition1.y, -mapHight, mapHight);*/
            acc *= Time.deltaTime;

            transform.Translate(acc * accelerationSpeed);
            anim.SetFloat("speed", acc.x);
            if (acc.x > 0)
            {
                anim.SetBool("right", true);
            }
            else
            {
                anim.SetBool("right", false);
            }
            if (acc.sqrMagnitude > 1)
            {
                acc.Normalize();
            }
           
        }

#endif
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Enemy")
        {
            //  FindObjectOfType<Block>().Die();
            if (!hit)
            {
                hit = true;
                anim.SetBool("hit", hit);
                 Die();
                
                FindObjectOfType<GM>().EndGame();
               // FindObjectOfType<PlayerSpawnerScript>().Respwan();
                Debug.Log("Hit");
               
                StartCoroutine(Wait1());
                ren.sprite = player;
                
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D obj)
    {

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
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitForTime);
    }
    IEnumerator PowerUPTime()
    {
        yield return new WaitForSeconds(powerUpTime);
    }
    IEnumerator Wait1()
    {
        yield return new WaitForSeconds(1f);
    }
    /* public float GravityScale()
     {
         factor = Random.Range(1, rangeParameter);
         gravityScale = 1f/ factor*Time.fixedDeltaTime;
         return gravityScale;

     }*/
    void Die()
    {
        source.PlayOneShot(hitSound, 1f);
        ren.sprite = hitPrefab;
        //Instantiate(hitPrefab, transform.position, Quaternion.identity);
        //  Destroy(gameObject);

    }
    public void GetTriggerInverse(bool trigger1)
    {
        trigger = trigger1;
    }

}
