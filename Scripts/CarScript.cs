using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float speedFactor = 0.5f;
   // public AudioClip hornSound;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        source.Play();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -2f)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject, 1f);
        }
    }
}
