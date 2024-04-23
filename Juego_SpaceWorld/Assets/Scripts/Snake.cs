using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
     private Rigidbody2D rBody;

    private AudioSource source;

    public BoxCollider2D boxCollider;

    
    
    public AudioClip deathSound;
    
    public float enemySpeed = 5;

    public float enemyDirection = 1;
   
    // Start is called before the first frame update
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    void FixedUpdate()
    {
        rBody.velocity = new Vector2(enemyDirection * enemySpeed, rBody.velocity.y);  
    }
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            if(enemyDirection == 1)
        {
            enemyDirection = -1;

        }
        else if(enemyDirection == -1)
        {
            enemyDirection = 1;
            
        }

        }
        
        if(collision.gameObject.tag == "Player")
        {
            
          PlayerMovement player=GameObject.FindObjectOfType<PlayerMovement>();
          player.TravisDeath();
        }
    }

    public void GoombaDeath()
    {
        
        source.PlayOneShot(deathSound);
        boxCollider.enabled = false;
        rBody.gravityScale = 0;
        enemyDirection = 0;
        Destroy(gameObject, 0.5f);
    }
}
