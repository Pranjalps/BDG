using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject powerUpEffect;
   // public AudioClip powerUpSound;
    private AudioSource source;
    int lives;

    //public float gravityScale = 35f;
    // Start is called before the first frame update
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Start()
    {
        
        // GetComponent<Rigidbody2D>().gravityScale += FindObjectOfType<GM>().GravityScale();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -4f)
        {
            Destroy(gameObject);
        }
        
    }
   

    public void Die()
    {
        lives = PlayerPrefs.GetInt("PlayerCurrentLives");
        lives += 1;
        PlayerPrefs.SetInt("PlayerCurrentLives", lives);
        float vol = 1f;
        source.volume = vol;
        source.Play();
        Instantiate(powerUpEffect, transform.position, Quaternion.identity);
        Destroy(gameObject,0.1f);
    }
    void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.gameObject.tag != "player")
        {
            Destroy(gameObject);
        }
    }
    
}
