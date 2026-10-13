using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible2D : MonoBehaviour
{

    public float rotationSpeed = 0.5f;
    public GameObject onCollectEffect;

    // Update is called once per frame
    void Update()
    {
        //we are rotating every frame based on rotationSpeed
        transform.Rotate(0, 0, rotationSpeed);
        
    }

    //OnTriggerEnter2D Collider2D was triggered
    private void OnTriggerEnter2D(Collider2D other) {
        
         // Check if the other object has a PlayerController2D component
         //Making sure other game objects do not interact with the collectible 
        if (other.GetComponent<PlayerController2D>() != null) {
            
            // Destroy the collectible
            Destroy(gameObject);

            // Instantiate the particle effect
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }

        
    }


}


