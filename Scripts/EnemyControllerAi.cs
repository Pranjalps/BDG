using UnityEngine;
//using UnityEngine.AI;
public class EnemyControllerAi : MonoBehaviour
{
    public float lookRadius = 10f;
    public float speed=5f;
    //Vector2 velocity = new Vector2(0.5f, 0.5f);
    Transform target;
    Rigidbody2D rb;
    // NavMeshAgent agent;
    // Start is called before the first frame update

    public AudioClip enemyDieSound;
  //  private AudioSource source;
    public GameObject deathEffect;

    void Awake()
    {

       //  source = GetComponent<AudioSource>();//attach soundsource
    }
    void Start()
    {
        target = PlayerManager.instance.player.transform;//get instance of player
        // agent = GetComponent<NavMeshAgent>();
       // rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ///to make enemy attack player
        float distance = Vector2.Distance(target.position, transform.position);//get difference of distance between enemy and player 
        if (distance <= lookRadius)
        {
            //transform.LookAt(target.position);
            //Vector2 newPosition = target.position;
            //newPosition += velocity * Time.fixedDeltaTime;
            //agent.SetDestination(target.position);
            // rb.MovePosition(newPosition);
            //rb.AddForce(newPosition, ForceMode2D.Impulse);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);//Move enemy toward player
        }
        else
        {
            Vector2 tr = Vector2.zero;
            tr.y = 1f;
            transform.position = Vector2.MoveTowards(transform.position, tr, speed * Time.fixedDeltaTime);
        }
        
    }
    //draw wire sphere to check if player is in radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;//color of wiresphere
        Gizmos.DrawWireSphere(transform.position, lookRadius);//draw wiresphere
    }
    /*  private void OnCollisionEnter2D(Collision2D coll)
      {
          if (coll.gameObject.tag == "Player")
          {

              Destroy(coll.gameObject);
          }

      }*/

        /// <summary>
        /// check if collided with enemy
        /// </summary>
        /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<GM>().EndGame();
          FindObjectOfType<EnemyHealthScript>().TakeDamage(10);
        }
    }

   /*  void Die()
    {
        // float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(enemyDieSound, 1);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.11f);
    }*/
}
