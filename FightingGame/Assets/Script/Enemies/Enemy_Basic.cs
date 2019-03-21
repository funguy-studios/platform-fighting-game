using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Basic : MonoBehaviour
{
    Rigidbody2D enemy;
    int move = 0;
    const float movespeed = 1f;
    int direction = -1; //1 == right -1 == left
    public int maxmove;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move Object
        Move();
    }
    //Movement
    private void Move()
    {
        //Check for ground infront of object
        Vector2 _270 = -Vector2.up + (Vector2.right * direction);
        var hit = Physics2D.Raycast(transform.position, _270, 10f);
        //If not change the direction
        if (!hit || hit.collider.tag != "Ground")
        {
            direction *= -1;
            move = 0;
        }
        //Change direction if gets to max distance
        if (move >= maxmove)
        {
            direction *= -1;
            move = 0;
        }
        //Increase Movement time
        move++;
        //Move the enemy
        enemy.velocity = new Vector2(movespeed * direction, enemy.velocity.y);
    }


    //Kill Player(Will Be updated in the future when health system is in)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }

    }
}
