using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Velocity
{
    public float minX, maxX, minZ, maxZ;
}
public class Rotator : MonoBehaviour {
    public Velocity velocity;
    public float tumble;
    public float speed;
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
        rb.velocity = new Vector3(Random.Range(velocity.minX, velocity.maxX), 0, Random.Range(velocity.minZ, velocity.maxZ))*speed;
    }
	
	// Update is called once per frame
	void Update () {
    }
    private void FixedUpdate()
    {
        
    }
}
