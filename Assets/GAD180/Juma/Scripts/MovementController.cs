using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody rigidBody;
    Vector3 _EulerAngleVelocity;
    Vector3 movement = Vector3.zero;
    public int gravity = 40;
    int recoil = 2000;
    bool isGrounded;
    public int speed = 100;
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
            rigidBody.velocity += transform.forward * speed / 50;
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

        var vec = new Vector2(rigidBody.velocity.x, rigidBody.velocity.z);
        if (vec.magnitude> speed)
        {
            vec = vec.normalized * speed;
        }
        rigidBody.velocity = new Vector3(vec.x, rigidBody.velocity.y, vec.y);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GameObject bulletCreation = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        //    Rigidbody bulletCreatingRB = bulletCreation.GetComponent<Rigidbody>();
        //    bulletCreatingRB.AddForce(Vector3.forward * bulletSpeed);
        //}

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
