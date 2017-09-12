using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    public float Movementspeed;
    public Transform plane1;

    private float offsetY;


    private void Start()
    {
        Movementspeed = 1f;
        offsetY = transform.position.y - plane1.position.y;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(-vertical, horizontal, 1);
        /*
        bool left = Input.GetButton("Left");
        bool right = Input.GetButton("Right");
        bool up = Input.GetButton("Up");
        bool down = Input.GetButton("Down");


        if (left == true)
        {
            Move(0, -1, 1);
        } else if (right == true)
        {
            Move(0, 1, 1);
        }

        if (up == true)
        {
            Move(-1, 0, 1);
        } else if (down == true)
        {
            Move(1, 0, 1);
        }*/
        

    }

    void Move(float x, float z, float Deltatime)
    {
        transform.Translate((new Vector3(x, 0, z) * Deltatime) * Movementspeed);
        CheckGround();
    }

    void CheckGround()
    {
        Vector3 down = -transform.up;
        Debug.DrawRay(transform.position, down * 10, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, down, out hit))
        {
            //Debug.Log(hit.transform.name);

            Quaternion rotation = Quaternion.FromToRotation(transform.up, hit.normal);
            transform.Rotate(rotation.eulerAngles, Space.World);

            // Maak rotatie van y gelijk aan de huidige y rotatie.

            if(hit.transform.position.y != offsetY)
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
