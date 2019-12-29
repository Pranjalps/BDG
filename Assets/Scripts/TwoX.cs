using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoX : MonoBehaviour
{
    public GameObject powerUpEffect;
    //public AudioClip powerUpSound;
    private AudioSource source;
    // public float gravityScale = 35f;
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
        if (transform.position.y < -2f)
        {
            Destroy(gameObject);
        }
        
    }
    public void Die()
    {
        Time.timeScale = 1f;
        float vol =1f;
        source.volume=vol;
       
        source.Play();
        Instantiate(powerUpEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }







}
