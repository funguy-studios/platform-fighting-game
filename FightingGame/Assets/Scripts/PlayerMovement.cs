using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocity = 5;
    public float jumpHeight = 5;
    public bool groundCheck;
    Vector2 input;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        GetInput();
        Jump();

        if (input.magnitude > 0.5f)
        {
            input.Normalize();
        }
        else
        {
            return;
        }
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
        if (Input.GetButtonDown("Jump") && groundCheck)
        {

            rb.velocity = new Vector3(0, jumpHeight);
            groundCheck = false;
            {

            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            groundCheck = true;
        }
    }
}