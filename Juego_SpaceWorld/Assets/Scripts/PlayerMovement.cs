using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
   
   
   void Awake()
   {
    
    rBody = GetComponent<Rigidbody2D>();    
    render = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();  

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
