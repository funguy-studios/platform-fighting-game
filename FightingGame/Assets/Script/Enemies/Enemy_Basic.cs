using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy_Basic : MonoBehaviour
{
    public float offsetx=.55f;
    Rigidbody2D enemy;
    int move = 0;
    int direction = -1; //1 == right -1 == left
    GameObject player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GetComponent<Rigidbody2D>();
    } 

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position)>=9) { Move(); }
        else { MoveTowardsPlayer(); }
        

    }
    //Movement
    public void Move()
    {
        //Change Offset depending on direction
        if (direction == 1) { offset.x = offsetx; }
        else { offset.x = -offsetx; }
        //Check for ground infront of object
        Vector2 _270 = -Vector2.up + (Vector2.right * direction);
        var hit = Physics2D.Raycast(transform.position+offset, _270, 10f);
        Debug.DrawRay(transform.position + offset, _270, Color.white);
        //If not change the direction
        if (!hit || hit.collider.gameObject.tag != "Ground")
        {
            Debug.Log("SWITCH");
            direction *= -1;
            move = 0;
        }
        //Change direction if gets to max distance
        if (move >= 650)
        {
            direction *= -1;
            move = 0;
        }
        //Increase Movement time
        move++;
        //Move the enemy
        enemy.velocity = new Vector2(direction, enemy.velocity.y);
    }

    //Move towards player if they are near
    public void MoveTowardsPlayer()
    {
        Debug.Log("MOVING TOWARDS PLAYER");
    }


    //Kill Player(Will Be updated in the future when health system is in)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
