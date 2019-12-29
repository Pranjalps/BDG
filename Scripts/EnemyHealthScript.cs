using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Enemy Health Controlles
/// </summary>
public class EnemyHealthScript : MonoBehaviour
{
   
    public AudioClip enemyDieSound;//audio clip to play when enemy dies
    private AudioSource source;//audiosource to play the sound
   // private float volLowRange = .9f;
    private float volHighRange = 0.5f;//volume of audiosource

    public int health = 100;//enemy health
    public GameObject deathEffect;//effect to show when enemy dies
   
    void Awake()
    {
        
        source = GetComponent<AudioSource>();//get audiosource component
    }
    //function to reduce health when enemy is hit
    public void TakeDamage(int damage)
    {
        health -= damage;//reduction of healt
        if (health <= 0)
        {//if health is 0 or less than it
            //kill enemy
            Die();//die function is called
        }
    }
    //function to show enemy death
    public void Die()
    {
       // float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(enemyDieSound, volHighRange);//play death sound
        Instantiate(deathEffect, transform.position, Quaternion.identity);//show deatheffect
        Destroy(gameObject,0.3f);//destroy enemy
    }
   
}
