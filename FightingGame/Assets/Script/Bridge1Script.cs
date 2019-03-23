using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge1Script : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey("e"))
        {
            animator.SetTrigger("ButtonPressed");
        }
    }
}
