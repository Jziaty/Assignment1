using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float Movementspeed;
    public Transform plane1;
    public Transform Firepoint;
    public Transform Cannon;

    private Vector3 InitPos;
    private Quaternion InitRot;

    private float offsetY;


    private void Start()
    {
        InitRot = transform.rotation;
        InitPos = transform.position;
        Movementspeed = 1f;
        offsetY = transform.position.y - plane1.position.y;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(-horizontal, -vertical, 1);

        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
        
    }

    void Move(float x, float z, float Deltatime)
    {
        transform.Translate((new Vector3(x, 0, z) * Deltatime) * Movementspeed);
        CheckGround();
    }

    void Shoot()
    {
        Vector3 back = -Firepoint.transform.forward;

        Debug.DrawRay(Firepoint.transform.position, Firepoint.transform.forward * 100, Color.cyan, 1.0f);

        RaycastHit hit;
        if(Physics.Raycast(Firepoint.transform.position, Firepoint.transform.forward, out hit, 1000))
        {
            Debug.Log(hit.transform.name);
            Destroy(hit.transform.gameObject, 2f);
        }
    }

    public void ResetPos()
    {
        Debug.Log("InitPos changed");
        transform.position = InitPos;
    }

    void CheckGround()
    {
        Vector3 down = -transform.up;
        Debug.DrawRay(transform.position, down * 10, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, down, out hit))
        {
            //Debug.Log(hit.transform.name);
            transform.rotation = InitRot;

            Quaternion rotation = Quaternion.FromToRotation(transform.up, hit.normal);
            transform.Rotate(rotation.eulerAngles, Space.World);

            if (hit.transform.position.y != offsetY)
            {
                CheckHeight();
            }

        }
    }

    void CheckHeight()
    {
        transform.position = new Vector3(transform.position.x, offsetY, transform.position.z);
    }
}
