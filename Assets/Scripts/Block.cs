using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //public float gravityScale = 20f;
    public GameObject blockDeathEffect;
    public AudioClip blockSound;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Start()
    {
        // GetComponent<Rigidbody2D>().gravityScale = FindObjectOfType<PlayerOriginal>().GravityScale();
    }
    // Update is called once per frame
    void Update()
    {



        if (transform.position.y < -2f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Die();
        }
    }
     void Die()
    {
        Time.timeScale = 1f;
        float vol = 1f;
        //source.volume = vol;

        source.PlayOneShot(blockSound, vol);
        Instantiate(blockDeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
