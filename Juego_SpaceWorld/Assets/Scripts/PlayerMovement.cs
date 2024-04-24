using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rBody;
   
    public Vector3 newPosition = new Vector3(1, 1, 1);

    public float movementSpeed = 5;
    public float jumpForce = 10;

    private float inputHorizontal;

    public bool jump = false;

    public GroundSensor sensor;

    public SpriteRenderer render;

    public Animator anim;

    public AudioClip deathSound;

    AudioSource source;

    private bool canShoot = true;

    public Transform bulletSpawn;

    public GameObject bulletPrefab;

    public float rateOfFire = 1;

    public float timer;

    public bool canMove = true;

    public bool isDeath = false;

    public Renderer sprite;

   
   
   
   void Awake()
   {
    
    rBody = GetComponent<Rigidbody2D>();    
    render = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();  
    source = GetComponent<AudioSource>();
    sprite = GetComponent<Renderer>();

    

   }

     
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Shoot();
        if(canMove == true)
        {
            inputHorizontal = Input.GetAxis("Horizontal");

        }
        else
        {
            inputHorizontal = 0;
        }
        
        
        

        if(Input.GetButtonDown("Jump") && sensor.isGrounded == true && canMove == true)
        {   
            
            rBody.AddForce(new Vector2(0,1) * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);

         }
           if(inputHorizontal < 0)
        {
            //render.flipX = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("isRunning", true);
        }
        else if(inputHorizontal > 0)
        {
            //render.flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    void CanMove()
    {
        canMove = true;
    }

    void CantMove()
    {
        canMove = false;
    }



    void FixedUpdate()
    {
        rBody.velocity = new Vector2(inputHorizontal * movementSpeed, rBody.velocity.y);
    
    }



   void OnCollisionEnter2D(Collision2D collision)
   {
    if(collision.gameObject.tag=="Void")
    {
        //TravisDeath();

        StartCoroutine("Die");
        
    }
    }
   
   public IEnumerator Die()
     {
        isDeath = true;
        sprite.enabled = false;
        yield return new WaitForSeconds(1);
        source.PlayOneShot(deathSound);
    }


    public void TravisDeath()
    {
        source.PlayOneShot(deathSound);
       
        Destroy(gameObject);
    }


    void Shoot()
    {
        if(!canShoot)
        {
            timer += Time.deltaTime;
            if(timer>= rateOfFire)
            {
                canShoot = true;
                canMove = true;
                timer = 0;
            }

        }
        if(Input.GetKeyDown(KeyCode.F) && canShoot)
        {
           anim.SetBool("isAttacking", true);
            Instantiate(bulletPrefab, bulletSpawn.position,bulletSpawn.rotation);

            canShoot = false;
            canMove = false;
        }
    }
    

}
