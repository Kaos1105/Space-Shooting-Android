using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {
    public GameObject shot;
    public Transform []shotSpawns;
    //public float nextFire;
    public float fireRate;
    public float delay;
    public Quaternion[] shotSpawnRotation;
    //public float reapeatTime;
    // Use this for initialization
    void Start () {
        InvokeRepeating("Shoot", delay, fireRate);
        shotSpawnRotation = new Quaternion[shotSpawns.Length];
        for (int i = 0; i < shotSpawns.Length; i++)
            shotSpawnRotation[i] = shotSpawns[i].rotation;
    }
	
	// Update is called once per frame
	void Update () {
        //Shoot();

    }
    void Shoot()
    {
        foreach (var shotSpawn in shotSpawns)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
    private void LateUpdate()
    {
        for (int i = 0; i < shotSpawns.Length; ++i)
        {
            shotSpawns[i].rotation = shotSpawnRotation[i];
        }
    }
}
