using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    MovementController player1;
    MovementController player2;
    Rigidbody rigidBody;
    Vector3 _EulerAngleVelocity;
    Vector3 movement = Vector3.zero;
    public int gravity = 40;
    int recoil = 2000;
    bool isGrounded;
    public int speed = 100;
    public ParticleSystem exhaust1;

    void Start()
    {
        _EulerAngleVelocity = new Vector3(0, 100, 0);
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<MovementController>();
    }

    void FixedUpdate()
    {//FIX POST PROCESSING
        //START PLAYER 1
        if (gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rigidBody.velocity += transform.forward * speed / 50;
                exhaust1.Emit (1);
            }
            else
            {
                exhaust1.Stop();
            }

            if (Input.GetKey(KeyCode.S))
            {
                rigidBody.velocity += -transform.forward * speed / 50;
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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded == true)
                {
                    rigidBody.AddForce(Vector3.up * 1000);
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                tankRecoil();
            }

            if (isGrounded == true)
            {

            }
            else
            {
                if (rigidBody.velocity.y <= 0)
                {
                    rigidBody.AddForce(-transform.up * gravity);
                }
            }
            //===============speed maxing
            var vec = new Vector2(player1.rigidBody.velocity.x, player1.rigidBody.velocity.z);
            if (vec.magnitude > speed)
            {
                vec = vec.normalized * speed;
            }
            player1.rigidBody.velocity = new Vector3(vec.x, player1.rigidBody.velocity.y, vec.y);
        }
        //END PLAYER 1

        //START PLAYER 2
        if (gameObject.tag == "Player2")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rigidBody.velocity += transform.forward * speed / 50;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                rigidBody.velocity += -transform.forward * speed / 50;
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

            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                if (isGrounded == true)
                {
                    rigidBody.AddForce(Vector3.up * 1000);
                }
            }

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                tankRecoil();
            }

            if (isGrounded == true)
            {

            }
            else
            {
                if (rigidBody.velocity.y <= 0)
                {
                    rigidBody.AddForce(-transform.up * gravity);
                }
            }
            //======speed maxing
            var vec = new Vector2(player2.rigidBody.velocity.x, player2.rigidBody.velocity.z);
            if (vec.magnitude > speed)
            {
                vec = vec.normalized * speed;
            }
            player2.rigidBody.velocity = new Vector3(vec.x, player2.rigidBody.velocity.y, vec.y);
        }
        //END PLAYER 2
    }

    void tankRecoil()
    {
        rigidBody.AddForce(-transform.forward * recoil);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }
}
