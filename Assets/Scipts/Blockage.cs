﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        //Debug.Log(other);
    }
}
