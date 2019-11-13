using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing2 : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePoint;

    public float Rate = 0.2f;
    private float Timer = 0f;

    void Update()
    {
        Timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && Timer > Rate)
        {
            Fire();
            Timer = 0f;
        }
    }

    void Fire()
    {
        GameObject Bullet_Clone = Instantiate(Bullet, FirePoint.position, FirePoint.rotation) as GameObject;
    }
}