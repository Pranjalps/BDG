using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// using tags define class pre built in unity and used to ensure faster and better performance
/// </summary>

public class Player03ControllerScript : MonoBehaviour
{
    /// <summary>
    /// variable declaration for use
    /// and initialization
    /// </summary>
    public float speed = 15f;     //speed of player using keyboard
    
    public float mapWidth = 5f;         //decide the width for player while using keyboard
    public float mapHight = 5f;          //decide the hight for player while using keyboard
    public bool hit = false;          //check if player is hit or not
    public int rotationOffset;          //calculating rotation differnce from orientation
    float waitForTime = 0.5f;          //Time to wait after hit
    public float accelerationSpeed = 10f;   //speed of player while using device acceleration to control it
    private bool facingRight = true;   //bool to check if player is facing right or left
    public bool trigger=false;  //check if controll should rotate the player while using device or not
    Vector3 originalPosition;

    /// <summary>
    /// variable declared for Testing purposes not to be included in game
    /// </summary>

    //float powerUpTime = 2f;
    //float gravityScale;
    //int factor;
    // public int rangeParameter=4;
    //int lives;

    // [RequireComponent (sprites)]


 /*   public Vector3 virtualMousePosition { get; private set; }
    public enum AxisOptions
    {
        ForwardAxis,
        SidewaysAxis,
    }
    public AxisMapping mapping;


    public AxisOptions tiltAroundAxis = AxisOptions.ForwardAxis;
    public float fullTiltAngle = 25;
    public float centreAngleOffset = 0;*/


    
   /* private void OnEnable()
    {
        
    }*/

        ///Main Function and the function definitons are started here
        ///

    Rigidbody2D rb;       //variable to acces the physics of player and control them from script

    /// <summary>
    /// Start function used for initialization and always starts at begining
    /// </summary>
    void Start()
    {
        Time.timeScale = 1f;  //change the time rate to full/ normal in game play
        //lives = PlayerPrefs.GetInt("PlayerCurrentLives");
        //ToIncrease player movement till screen
        // mapWidth = Screen.width;
        accelerationSpeed = PlayerPrefs.GetFloat("PlayerSurvivalSpeed",5f);      //Get acceleration speed from prefs stored in main menu scene

        rb = GetComponent<Rigidbody2D>();   //initialize rb with original component by GetComponent Of Type Rigidbody2d 
        //Its 2D Physics So Rigidbody2d
        originalPosition = rb.position;
       
    }//Caled once per The Execution Completes Of Inside Function
    void Update()
    {
#if UNITY_EDITOR||UNITY_STANDALONE
        //check trigger and if true rotate the player with mouse pointer
        //if (trigger) {
        //get difference bw mouse position and transform position(Player) in accordance with camera
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; 
            //normalize the vector to work beter
        difference.Normalize();
            //find the mouse position in deg using Mathf.Rad2Deg function
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            //apply transformation using transform.rotation and Quaternion.Euler agle for precision
       transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
        //check if player is facing  right or left and wants to move right or left and allign them
        //if input is moving the player right and player is facing left
       
        // }
        //get horizontal (left and right) axis change value and store it in float
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        //get vertical (up and down) axis change value and store it in float
        float y = Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed;
        // rangeParameter = Random.Range(2, 8);
      
       

        //store x and y value in new vector2 
        Vector2 value = new Vector2(1 * x, 1 * y);
        //add value to its current position
        Vector2 newPosition = rb.position +value ;

        //clamp the Movement Area
        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, -mapHight, mapHight);
        //Aplly Transform 
        rb.MovePosition(newPosition);
#endif 
       

        //Check if player is hit 
        if (hit)
        {
            StartCoroutine(Wait()); // start couroutine to change the time scale and wait for time and not execute any thng
            hit = false;  //set hit =flase
        }

        /// Android Code Runs Only In Android

       
#if UNITY_ANDROID

        if (!trigger)
        {
            Axis();

        }
        else
        {
            TouchInput();
        }
        if (rb.position.y < -27)
        {
            rb.position = originalPosition;
        }
        if (rb.position.y > 16.9)
        {
            rb.position = originalPosition;
        }
        if (rb.position.x < -21.6)
        {
            rb.position = originalPosition;
        }
        if (rb.position.x > 19.5)
        {
            rb.position = originalPosition;
        }
        ///
        ///Controlles for joyStick But Not IMplemented Properly
        ///
       /* float angle = 0;
        if (Input.acceleration != Vector3.zero)
        {
            switch (tiltAroundAxis)
            {
                case AxisOptions.ForwardAxis:
                    angle = Mathf.Atan2(Input.acceleration.x, -Input.acceleration.y) * Mathf.Rad2Deg +
                            centreAngleOffset;
                    break;
                case AxisOptions.SidewaysAxis:
                    angle = Mathf.Atan2(Input.acceleration.z, -Input.acceleration.y) * Mathf.Rad2Deg +
                            centreAngleOffset;
                    break;
            }
        }

        float axisValue = Mathf.InverseLerp(-fullTiltAngle, fullTiltAngle, angle) * 2 - 1;
        switch (mapping.type)
        {
            case AxisMapping.MappingType.NamedAxis:
                UpdateEnumValue(axisValue);
                break;
            case AxisMapping.MappingType.MousePositionX:
                SetVirtualMousePositionX(axisValue * Screen.width);
                break;
            case AxisMapping.MappingType.MousePositionY:
                SetVirtualMousePositionY(axisValue * Screen.width);
                break;
            case AxisMapping.MappingType.MousePositionZ:
                SetVirtualMousePositionZ(axisValue * Screen.width);
                break;
        }
        transform.Translate(virtualMousePosition*Time.deltaTime);*/
#endif //android code ends here
    }//end of fixedUpdate


    /// <summary>
    /// function for player movement
    /// </summary>
    /// 
    //touch input function
    void TouchInput()
    {
        ///To Controll Player Using Touch 
        if (Input.touchCount > 0)
         {
             Touch touch = Input.GetTouch(0);

             Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
             //touchPosition.y = 0;
             touchPosition.z = 0;
             transform.Translate(touchPosition);

         }
    }
    //axis input function
    void Axis()
    {
        //create a new 3 dimensional vector and initialize it with zero
        Vector3 acc =  Input.acceleration;
       // acc = Quaternion.Euler(90, 0, 0)*acc;
        //get the device acceleration in variable of type vector3 and assign respective values which you want to change
        //acc.x = Input.acceleration.x;   //for changing players x axis according to device acceleration in x axis
       // acc.y = -Input.acceleration.y;  //for changing players y axis according to device acceleration in y axis

        /* if (acc.x > 0 && !facingRight)
         { // ... flip the player.
             Flip(); //call flip function
                     // Otherwise if the input is moving the player left and the player is facing right...
         }
         else if (acc.x < 0 && facingRight)
         {    // ... flip the player.
             Flip(); //call flip function
         }*/
        ///To Clamp The Position But It Does'nt Work Perfectly For Acceleration
        /*
        newPosition1.x = Mathf.Clamp(newPosition1.x, -mapWidth, mapWidth);
        newPosition1.y = Mathf.Clamp(newPosition1.y, -mapHight, mapHight);*/

        /// instead of clamping we used Walls At the boundry to prevent player from going out of play area

        //check if player is facing  right or left and wants to move right or left and allign them in android
        //if input is moving the player right and player is facing left


        acc.z = 0f;
        //normalize the vector if square of its magnitued is greater than unit so 
        //so the player moves unit distance for acceleration
        if (acc.sqrMagnitude > 1)
        {
            acc.Normalize();
        }


        //multipling with time.deltaTime To Fix The Speed In Any Device Not To Change According to frame
        //by doing this the player speed does not depend on device power
        acc.x *= Time.deltaTime;
        acc.y *= Time.deltaTime;
        acc.x *= accelerationSpeed;
        acc.y *= accelerationSpeed;
        //aplly transform with acceleration speed so the player cam move acceleration speed per second
        transform.Translate(acc );
       // rb.velocity = new Vector2(rb.velocity.x + acc.x, rb.velocity.y + acc.y);
    }
    //Flip Function Definition
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;
        //check trigger value
       // if (trigger)
     //   {
            //Rotate The Player 180 Degree
            //transform.Rotate(0f,180f, 0f);
       // }
        //else
        {
            // Multiply the player's x local scale by -1.
            Vector3 scale=transform.localScale;
            scale.x = scale.x * -1;

            transform.localScale = scale;
        }
    }

    //enumerator function to change or cause  time diffrence
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitForTime); //wait for waitforTime seconds
    }

    /// <summary>
    /// Detect wheather player collided with something and if than do according to 
    /// </summary>
    /// <param name="collision"></param>
    /// collision defines the object player collided with
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if player collided with enemy

        if (collision.gameObject.tag == "Enemy")
        {
            //call function EndGame of GM Script
            FindObjectOfType<GM>().EndGame();
            //Destroy(collision.gameObject);
            //Damage The Enemy Health By 10
            FindObjectOfType<EnemyHealthScript>().Die();

            // Debug.Log("Player Died");

            
        }
        //check if player collided with Health powerUp
        if (collision.gameObject.tag == "Health")
        {//Destroy gameObject which collided with player 
            collision.gameObject.GetComponent<Health>().Die();
            //and use / apply power up to player
            FindObjectOfType<GM>().HealthPowerUp();
        }
        //check if player collided with TwoXPowerUp
        if (collision.gameObject.tag == "TwoX")
        {
            //Destroy gameObject which collided with player
            collision.gameObject.GetComponent<TwoX>().Die();
            //and use / apply power up to player
            FindObjectOfType<GM>().Twox();
            //Time.timeScale = 0.8f;
           
            
        }
    }


    /* public void Controles()
     {
         float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
         float y = Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed;

     } */


  /*  public void SetVirtualMousePositionX(float f)
    {
        virtualMousePosition = new Vector3(f, virtualMousePosition.y, virtualMousePosition.z);
    }


    public void SetVirtualMousePositionY(float f)
    {
        virtualMousePosition = new Vector3(virtualMousePosition.x, f, virtualMousePosition.z);
    }


    public void SetVirtualMousePositionZ(float f)
    {
        virtualMousePosition = new Vector3(virtualMousePosition.x, virtualMousePosition.y, f);
    }

    public void UpdateEnumValue(float f)
    { int i = (int)f;
        switch (i)
        {
            case 1:mapping.type = AxisMapping.MappingType.MousePositionX;

                break;
            case 2:
                mapping.type = AxisMapping.MappingType.MousePositionY;

                break;
            case 3:
                mapping.type = AxisMapping.MappingType.MousePositionZ;

                break;


        }

    }*/
    /// <summary>
    /// getting playerspeed from user from main menu scene
    /// </summary>
    /// <param name="newSpeed"></param>
    
    public void AdjustPlayerSpeed(float newSpeed)
    {
       accelerationSpeed = newSpeed;
    }

    /* [System.Serializable]
     public class AxisMapping
     {
         public enum MappingType
         {
             NamedAxis,
             MousePositionX,
             MousePositionY,
             MousePositionZ
         };

         public MappingType type;
         public string axisName;
     }*/
    /// <summary>
    /// getting trigger from user from main menu scene
    /// </summary>
    /// <param name="trigger1"></param>
    public void GetTriggerInverse(bool trigger1)
    {
        trigger = trigger1;
    }
    public bool GetDirection()
    {
        return facingRight;
    }
}
