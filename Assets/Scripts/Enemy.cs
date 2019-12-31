using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    //public float gravityScale = 20f;

    public GameObject enemyDeathEffect;
    public AudioClip blockSound;
    private AudioSource source;
    private BoxCollider2D bo;
    //float score;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        bo = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        //  score = PlayerPrefs.GetFloat("PlayerScore");
        //GetComponent<Rigidbody2D>().gravityScale = FindObjectOfType < PlayerLevel_02>().GravityScale();
    }
	// Update is called once per frame
	void Update () {
        
            if (transform.position.y < -5f) {
            Destroy(gameObject);
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bo.enabled = false;
            Die();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Die()
    {
        Time.timeScale = 1f;
        float vol = 1f;
        //source.volume = vol;

        source.PlayOneShot(blockSound, vol);
        Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
