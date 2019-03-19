using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logFadeScript : MonoBehaviour
{
    public Animator m_Animator;
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            m_Animator.SetTrigger("Fade");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            m_Animator.SetTrigger("Appear");
        }
    }
}
