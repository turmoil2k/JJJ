using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody rigidBody;
    Vector3 _EulerAngleVelocity;
    int speed = 20;
    //public GameObject bullet;
    //int bulletSpeed = 200;

    void Start()
    {
        _EulerAngleVelocity = new Vector3(0, 100, 0);
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.velocity = transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.velocity = -transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Quaternion deltaRotation = Quaternion.Euler(-_EulerAngleVelocity * Time.deltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Quaternion deltaRotation = Quaternion.Euler(_EulerAngleVelocity * Time.deltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GameObject bulletCreation = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        //    Rigidbody bulletCreatingRB = bulletCreation.GetComponent<Rigidbody>();
        //    bulletCreatingRB.AddForce(Vector3.forward * bulletSpeed);
        //}
    }
}
