using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Get ALL THE VARIABLES
    public float velocity = 5;
    public float jumpHeight = 5;
    public bool groundCheck;
    Vector2 input;
    private Rigidbody2D rb;
    Vector2 movement = new Vector2(0, 0);

    void Start()
    {
        //Get RB
        rb = GetComponent<Rigidbody2D>();
        //Set the movement vector to current velocity (for gravity)
        movement.y = rb.velocity.y;
    }


    void Update()
    {
        //ALL THE FUNCTIONS
        GetInput();
        Jump();
        Move();
        if (input.magnitude > 0.5f)
        {
            input.Normalize();
        }
        else
        {
            return;
        }
        //Actually Move with the vector
        rb.velocity = movement;
    }

    public void GetInput()
    {
        //Get input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    public void Move()
    {
        float horizontalMovement = (Input.GetAxis("Horizontal") * velocity)*20;
        //Flip Sprite
        if (horizontalMovement < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (horizontalMovement > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        //Frames for bad computers
        horizontalMovement *= Time.deltaTime;
        //Set movement x
        movement.x = horizontalMovement;
    }

    public void Jump()
    {
        //Check for able to jump
        if (Input.GetButtonDown("Jump") && groundCheck)
        {
            //Jumping
            movement.y = jumpHeight+rb.velocity.y;
            groundCheck = false;
        }
        else { movement.y = rb.velocity.y; }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //Change groundCheck variable
        if (other.gameObject.tag == "Ground")
        {
            groundCheck = true;
        }
    }
}