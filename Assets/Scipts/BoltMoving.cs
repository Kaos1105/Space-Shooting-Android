using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMoving : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public Rigidbody rb;
    public Boundary boundary;
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = (transform.TransformVector(Random.Range(boundary.xMin, boundary.xMax), 0.0f, Random.Range(boundary.zMin, boundary.zMax))) * speed;
        // rb.Addfore = direction *(transform.up)*speed;
    }
	
	// Update is called once per frame
	void Update () {

    }
}
