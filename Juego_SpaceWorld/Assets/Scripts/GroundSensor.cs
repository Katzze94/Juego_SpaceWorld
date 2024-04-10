using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    
    public bool isGrounded;

   public Animator anim;

   PlayerMovement playerScript;

   
   
   void Awake()
   {
    anim = GetComponentInParent<Animator>();
   playerScript = GetComponentInParent<PlayerMovement>();
   }
   
   void OnTriggerEnter2D(Collider2D collider)
   {

     isGrounded = true;
    anim.SetBool("isJumping", false);

   }

   void OnTriggerExit2D(Collider2D collider)
   {
    isGrounded = false;
   }
   
   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

