using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 0, 0);
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.rotation = Quaternion.Euler(45, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = offset + player.transform.position;
    }
}
