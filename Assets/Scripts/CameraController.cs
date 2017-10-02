using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject tank;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - tank.transform.position;
    }

    void LateUpdate()
    {
        transform.position = tank.transform.position + offset;
    }
}
