using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class Weapon : MonoBehaviour
{

    /// <summary>
    /// variable declaration for use
    /// and initialization
    /// </summary>
    /// 
    //bullet details
    public float fireRate = 0f;
    public float damage = 10f;
    public LayerMask whatToHit;
    public Transform[] bulletTrailPrefab;

   //sound details
    public AudioClip shootSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    //fire rate and point
    float timeToFire=0f;
    public int damageValue = 15;
    public Transform[] firePoint;

    //graphics effects
    public float effectSpwanRate = 10f;
    float timeToSpawnEffect = 0f;

    //gun sprites
    private SpriteRenderer spriteR;
    public Sprite[] sprites;

    //player score
    float score = 0;
    private bool facingRight;
    bool trigger=false;

    // Awake is called when a reference is declared
    void Awake()
    {
        //assign spritecomponent to variable so it can acces and change its properties
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        
        //get sound source
        source = GetComponent<AudioSource>();
        //find firepoint
       // firePoint[0] = transform.Find("FirePointRight");
        //firePoint[1] = transform.Find("FirePointLeft");
        //check if firePoint Exist or not
        if (firePoint[0] == null||firePoint[1]==null)
        {//show Log Output
            Debug.Log("No Fire Point");
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        trigger = FindObjectOfType<Player03ControllerScript>().trigger;
        facingRight = FindObjectOfType<Player03ControllerScript>().GetDirection();
        //get touch input to fire bullet
        
        if (Input.touchCount > 1)//if touch present
        {
            //store the touch input in variable of type touch
            Touch touch = Input.GetTouch(1);
            // get touch position in according to player window and store it in vector3 variable
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            //touchPosition.y = 0;
            //zero out z transform because its 2d game 
            touchPosition.z = 0;
            Shoot(touch); ///call shoot function with touch value as parameter
        }
        else if(Input.touchCount>0)
        {
           Touch touch = Input.GetTouch(0);
            // get touch position in according to player window and store it in vector3 variable
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            //touchPosition.y = 0;
            //zero out z transform because its 2d game 
            touchPosition.z = 0;
            Shoot(touch); ///call shoot function with touch value as parameter
        }


        //check burst or automatic mode
        if (fireRate == 0)
        {//check if button is pressed
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(); //call shoot function without parameter
            }
        }
        else
        {
            if (Input.GetButton("Fire1")&& Time.time>timeToFire)
            {//fire until
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
        
    }
    void Shoot()
    {
        //Get Firing Direction
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        int i;
        if (!trigger)
        {
            i = facingRight ? 0 : 1;
        }
        else
        {
            i= 0;
        }
        Vector2 firePointPosition = new Vector2(firePoint[i].position.x, firePoint[i].position.y);
        /* if (facingRight)
         {
             firePointPosition = new Vector2(firePoint[0].position.x, firePoint[0].position.y);
         }
         else
         {
             firePointPosition = new Vector2(firePoint[1].position.x, firePoint[1].position.y);
         }*/
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition,100,whatToHit);
        
        //Time To Fire
        if (Time.time >= timeToSpawnEffect)
        {
            Effect(i);
            timeToSpawnEffect = Time.time + 1 / effectSpwanRate;
        }
        Debug.DrawLine(firePointPosition, mousePosition, Color.cyan);// draw line to see the hit point
        if(hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);//change the color to red if hit 
            //check if the object that is hit is enemy
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<EnemyHealthScript>().TakeDamage(damageValue);//call function of enemy script to reduce the health of enemy
                FindObjectOfType<GM>().ScoreValueUpdate();//update score of player
                if (score < 1000)
                {
                    score += 1;
                }
                else
                {
                    FindObjectOfType<GM>().ScoreValueUpdate();
                    score += 2;
                    damageValue = 20;
                }
                //FindObjectOfType<EnemyHealthScript>().TakeDamage(damageValue);
            }
        }

    }
    void Shoot(Touch touch)
    {
        //same function as shoot but the touch is used instead of keyInput
        Vector2 touchPosition = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y);
        int i;
       // if (!trigger)
       // {
            i = facingRight ? 0 : 1;
        //}
       // else
       // {
           // i = 0;
       // }
        Vector2 firePointPosition = new Vector2(firePoint[i].position.x, firePoint[i].position.y);
       /* if (facingRight)
        {
            firePointPosition = new Vector2(firePoint[0].position.x, firePoint[0].position.y);
        }
        else
        {
             firePointPosition = new Vector2(firePoint[1].position.x, firePoint[1].position.y);
        }*/
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, touchPosition - firePointPosition, 100, whatToHit);

        if (Time.time >= timeToSpawnEffect)
        {
            Effect(i);
            timeToSpawnEffect = Time.time + 1 / effectSpwanRate;
        }
        Debug.DrawLine(firePointPosition, touchPosition, Color.cyan);
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<EnemyHealthScript>().TakeDamage(damageValue);
                FindObjectOfType<GM>().ScoreValueUpdate();
                if (score < 1000)
                {
                    score += 1;
                }
                else
                {
                    FindObjectOfType<GM>().ScoreValueUpdate();
                    score += 2;
                    damageValue = 20;

                }
                //FindObjectOfType<EnemyHealthScript>().TakeDamage(damageValue);
            }
        }
    }
    void Effect(int j)
    {
        //show bullet and shoot effect play sound
        float vol = Random.Range(volLowRange, volHighRange);//set volume of bullet
        source.PlayOneShot(shootSound, vol);//play sound
        int i = (int)score/1000; //set value for index to be used to show bullet
        i = i > 2 ? 2 : i;
        Instantiate(bulletTrailPrefab[i], firePoint[j].position, firePoint[j].rotation);//show bullet at index i
    }
    public void PlayerChanger(int i)
    {//change the player sprite
        if(i<sprites.Length)
        spriteR.sprite = sprites[i]; 
    }
}
