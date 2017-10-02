using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCannon : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float turret = Input.GetAxis("TankCannon");

        //transform.rotation = Quaternion.AngleAxis(turret * 10, Vector3.up);
        transform.Rotate(new Vector3(0, turret, 0), Space.World);

    }
}