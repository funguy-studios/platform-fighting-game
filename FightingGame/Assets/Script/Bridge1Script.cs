using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge1Script : MonoBehaviour
{
    public Animator m_Animator;
    private bool intractable;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (intractable == true && Input.GetKeyDown("e"))
        {
            m_Animator.SetTrigger("ButtonPressed");
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"){
            intractable = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player"){
            intractable = false;
        }
    }
}
