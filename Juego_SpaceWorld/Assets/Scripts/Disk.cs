using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{

    public BoxCollider2D boxCollider; 
    private AudioSource source;

    public AudioClip diskSound;

    public SpriteRenderer sprite;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        source = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") {
            source.PlayOneShot(diskSound);
            boxCollider.isTrigger=true;
            sprite.enabled=false;
            Destroy(gameObject, 0.5f);
        }
    }
}
