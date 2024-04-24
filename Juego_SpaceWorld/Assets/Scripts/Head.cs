using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
  
    public BoxCollider2D boxCollider;

    private AudioSource source;

    public AudioClip completed;

    public BGMManager bgmManager;





    void Awake()
  {
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        for (int i = 0; i < Mathf.Min(colliders.Length, 2); i++){
            if (i==0) boxCollider = colliders[i];
        }

        source=GetComponent<AudioSource>();

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            source.PlayOneShot(completed);
            AudioSource bgmSource = bgmManager.GetComponent<AudioSource>();
            bgmSource.Stop();
            

            

        }


    


    }
}
