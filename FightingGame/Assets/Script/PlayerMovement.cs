using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocity = 5;
    public float jumpHeight = 5;
    private bool groundCheck;
    private const int Max_Jump = 2;
    private int currentJump = 0;
    Vector2 input;
    private Rigidbody2D rb;
    public Transform player;
    private Transform floor;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        GetInput();
        Jump();
        Move();
    }

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
    void Move()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * velocity;

        if (horizontalMovement < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (horizontalMovement > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        horizontalMovement *= Time.deltaTime;
        transform.Translate(horizontalMovement, 0, 0);
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && (groundCheck || Max_Jump > currentJump))
        {

            rb.velocity = new Vector3(0, jumpHeight);
            groundCheck = false;
            currentJump++;
            {

            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            groundCheck = true;
            currentJump = 0;
            floor = other.gameObject.transform;
            player.rotation = floor.rotation;
        }
    }
}