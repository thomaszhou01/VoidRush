using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public PlayerMovement movement;


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag == "Object")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
