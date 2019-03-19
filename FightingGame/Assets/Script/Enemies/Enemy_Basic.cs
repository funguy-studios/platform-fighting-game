using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Basic : MonoBehaviour
{
    public Transform enemy;
    int move = 0;
    const int movespeed=6;
    int direction = 1; //1 == right -1 == left
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move++;
        if (move >= 200) { direction = direction * -1; }
        enemy.Translate(movespeed * direction, 0, 0);
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
