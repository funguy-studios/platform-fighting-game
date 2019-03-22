using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator1Script : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;
    private bool canMove = false;
    public int waitTime;
    public Animator anim;
    public GameObject lift;
    public GameObject player;

    private void Start()
    {
        GetComponent<Animator>().enabled = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canMove = true;
            player.transform.parent = lift.transform;

            if (Input.GetKey("e") && canMove == true)
            {
                anim.SetBool("LiftUp", true);
                GetComponent<Animator>().enabled = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canMove = false;
        player.transform.parent = null;

        if (canMove == false)
        {
            StartCoroutine(BackToStart());
        }
    }

    IEnumerator BackToStart()
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("LiftUp", false);
        GetComponent<Animator>().enabled = true;
    }
}