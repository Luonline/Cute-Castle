﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Michael Altair 
 *  This class controls the player character's movement
 */

public class PlayerController : MonoBehaviour {

    private bool grounded;

    public float moveSpeed;
    public float jumpPower = 10;

    public Vector3 velocity;

    public bool isGrown;

    // Use this for initialization
    void Start () {
        UpdateSize();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            PlayerMove(input);
        }


        // Detecting if the player is midair
        if(gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            grounded = true;
        } else
        {
            grounded = false;
        }
    }

    public void PlayerMove(Vector2 input)
    {
        float targetVelocityX = input.x * moveSpeed;
        velocity.x = targetVelocityX;
        transform.Translate(velocity * Time.deltaTime);

        if(input.y > 0)
        {
            PlayerJump();
        }
    }

    public void PlayerJump()
    {
        if (grounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x, jumpPower, 0), ForceMode2D.Impulse);
        }
    }

    // Collision logic
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            Hurt();
        } else if (other.gameObject.tag == "Power-Up")
        {
            PowerUp(other.gameObject);
        }

    }

    // Triggers when the player is injured
    public void Hurt()
    {
        
        if(isGrown)
        {
            Shrink();
        } else
        {
            Death();
        }
    }

    // Triggers on death
    private void Death()
    {
        Debug.Log("You Dead!");
    }

    // Handles Powerups
    private void PowerUp(GameObject powerUp)
    {
        if(powerUp.name == "Health-Up")
        {
            Grow();
        }



        // Destroys the powerup in the end
        Destroy(powerUp);
    }

    // Makes the character grow/shrink
    private void Grow()
    {
        if (!isGrown)
        {
            isGrown = true;
            UpdateSize();
        }
    }
    private void Shrink()
    {
        if(isGrown)
        {
            isGrown = false;
            UpdateSize();
        }
    }
    private void UpdateSize()
    {
        if(isGrown)
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 0f);
        } else
        {
            gameObject.transform.localScale= new Vector3(1f, 0.6f, 0f);
        }
    }
}
