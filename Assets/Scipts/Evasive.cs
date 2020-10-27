using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Evasive : MonoBehaviour {
    public float dodge;
    public Vector2 startWait;
    public Vector2 evasiveTime;
    public Vector2 evasiveWait;
    public float speed;
    public float tilt;
    public Boundary boundary;
    private float targetManeuver;
    private Rigidbody rb;
    //private Transform playerTransform;
  	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		StartCoroutine (Evade());
	}
	IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            //if (playerTransform != null)
            //    targetManeuver = playerTransform.position.x;
            yield return new WaitForSeconds(Random.Range(evasiveTime.x, evasiveTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(evasiveWait.x, evasiveWait.y)); 
        }
    }
	// Update is called once per frame 
	void FixedUpdate () {
        float newEvasive = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * speed);
        rb.velocity = new Vector3(newEvasive, 0.0f, rb.velocity.z);
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            2.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * tilt);
    }
}
