using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController2 : MonoBehaviour
{
    Rigidbody rigidBody;
    Vector3 _EulerAngleVelocity;
    int speed = 20;

    void Start()
    {
        _EulerAngleVelocity = new Vector3(0, 100, 0);
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidBody.velocity = transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidBody.velocity = -transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion deltaRotation = Quaternion.Euler(-_EulerAngleVelocity * Time.deltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion deltaRotation = Quaternion.Euler(_EulerAngleVelocity * Time.deltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        }
    }
}
