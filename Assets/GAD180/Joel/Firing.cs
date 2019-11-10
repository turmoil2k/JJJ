using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePoint;
    public float Rate = 0.2f;
    private float Timer = 0f;

    void Update()
    {
        Timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && Timer > Rate)
        {
            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            Timer = 0f;
        }
    }
}
