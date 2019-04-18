using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ahgase : MonoBehaviour
{
    public float upForce = 200f;                   //Upward force of the "flap".
    private bool isDead = false;            //Has the player collided with a wall?


    private Rigidbody2D rb2d;               //Holds a reference to the Rigidbody2D component of the bird.

    void Start()
    {

        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Don't allow control if the bird has died.
        if (isDead == false)
        {
            //Look for input to trigger a "flap".
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

              
                //...zero out the birds current y velocity before...
                rb2d.velocity = Vector2.zero;
                //  new Vector2(rb2d.velocity.x, 0);
                //..giving the bird some upward force.
                rb2d.AddForce(new Vector2(0, upForce));
            }else if
                     (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rb2d.velocity = Vector2.right;


            }
            else if ((Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                rb2d.velocity = Vector2.left;

            }

            Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            if (screenPosition.y > Screen.height || screenPosition.y < 0)
            {
                isDead = true;
                GameControl.instance.BirdDied();
            }
            else if (screenPosition.x > Screen.width || screenPosition.y < 0)
            {
                isDead = true;
                GameControl.instance.BirdDied();
            }
        }
    }

   


    void OnCollisionEnter2D(Collision2D other)
    {
        // Zero out the bird's velocity
        rb2d.velocity = Vector2.zero;
        // If the bird collides with something set it to dead...
        isDead = true;

        ////...and tell the game control about it.
        GameControl.instance.BirdDied();
    }
}