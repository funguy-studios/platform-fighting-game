using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator1Script : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;
    private void Update()
    {
        if (Input.GetKey("e"))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
    }
}
