using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Rigidbody player;
    int hormove;
    int zmove;
    // Start is called before the first frame update
    void Start()
    {
            player = gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        if (Input.GetKey("up")) { zmove = 1; }
        else if (Input.GetKey("down")) { zmove = -1; }
        else { zmove = 0; }
        if (Input.GetKey("right")) { hormove = 1; }
        else if (Input.GetKey("left")) { hormove = -1; }
        else { hormove = 0; }
        Vector3 move = new Vector3(hormove * 5, player.velocity.y, zmove * 5);
        player.velocity = move;
    }
    void OnCollisionStay(Collision collision)
    {
            if (Input.GetKey(KeyCode.Space)&&collision.collider.tag=="Ground")
            {
                player.velocity = new Vector3(player.velocity.x, 5, player.velocity.z);
            }
        }

}
