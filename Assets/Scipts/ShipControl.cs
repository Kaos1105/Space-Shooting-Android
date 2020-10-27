using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class ShipControl : MonoBehaviour {

    private Rigidbody rb;
    public Boundary boundary;
    public float tilt;
    public float speed;
    public GameObject shot;
    public GameObject []shotSpawns;
    public float nextFire;
    public float fireRate;
    private int numPowers;
    private SimpleTouchPad touchpad;
    public Quaternion []shotSpawnRotation;
    private Quaternion calibrationQuaternion;
    // Use this for initialization
    void Start()
    {
        numPowers = 0;
        rb = GetComponent<Rigidbody>();
        shotSpawnRotation= new Quaternion [shotSpawns.Length];
        for (int i=0; i<shotSpawns.Length;i++)
            shotSpawnRotation[i] = shotSpawns[i].transform.rotation;
        touchpad = GameObject.FindGameObjectWithTag("TouchPad").GetComponent<SimpleTouchPad>();
    }
    private void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //Vector3 accelerationRaw = Input.acceleration;
        //Vector3 acceleration = FixAcceleration(accelerationRaw);
        //Vector3 movement = new Vector3(acceleration.x, 0.0f, acceleration.y);
        Vector2 direction = touchpad.GetDirection();
        Vector3 movement = new Vector3(direction.x, 0.0f, direction.y);
        rb.velocity = movement * speed;
        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            2.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * tilt);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                if (shotSpawn.activeInHierarchy)
                    Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            }
        }
    }
    private void LateUpdate()
    {
        for(int i=0; i< shotSpawns.Length;++i)
        {
            shotSpawns[i].transform.rotation = shotSpawnRotation[i];
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUP"))
        {
            numPowers++;
            Debug.Log(numPowers);
            if (numPowers<shotSpawns.Length)
            {
                shotSpawns[numPowers].SetActive(true);
            }
        }
    }
    void CalibrateAcceleremoter()
    {
        Vector3 accelerationSnapshot = Input.acceleration;
        Quaternion rotateQuarternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, 1.0f), accelerationSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuarternion);
    }
    Vector3 FixAcceleration(Vector3  accleration)
    {
        Vector3 fixedAcceleration = calibrationQuaternion * accleration;
        return fixedAcceleration;
    }
}
