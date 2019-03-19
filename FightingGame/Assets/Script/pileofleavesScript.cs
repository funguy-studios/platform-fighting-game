using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pileofleavesScript : MonoBehaviour
{
    private BoxCollider2D colli;
    void Start()
    {
        colli = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"){
            colli.enabled = false;
        }
    }
}
