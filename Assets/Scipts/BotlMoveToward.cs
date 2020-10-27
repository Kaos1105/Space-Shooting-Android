using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotlMoveToward : MonoBehaviour {
 // Use this for initialization
    public float speed;
    public Rigidbody rb;
    //public Boundary boundary;
    void Start () {

        rb = GetComponent<Rigidbody>();
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            //var angle = player.transform.position - transform.position;
            //angle.x *= -1;
            //rb.velocity = transform.TransformVector(angle * speed);
            rb.transform.LookAt(player.transform);
            rb.velocity = transform.forward * speed;
        }
        else
            rb.velocity = -transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
