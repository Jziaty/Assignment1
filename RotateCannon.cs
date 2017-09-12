using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCannon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float turret = Input.GetAxisRaw("TankCannon");

        transform.rotation = Quaternion.AngleAxis(turret, Vector3.up);
        
    }
}
