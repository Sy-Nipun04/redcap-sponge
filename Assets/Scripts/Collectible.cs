using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    int collectible;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);                            //Destroys collided gameobject tagged "Collectible" 
            collectible++;

            //Add more code for added effect like powerups, healing, damage taken, etc.
        }
    }
}

/* This Script is to be attached to the gameObject that will collide(trigger) with the collectible.
 * E.g. bullet(script attached) -> enemy(collectible) OR player(script attached) -> points(collectible). */
