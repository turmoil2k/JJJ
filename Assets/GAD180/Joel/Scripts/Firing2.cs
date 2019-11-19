using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Firing2 : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePoint;
    public InputManager FireInput;

    public float rate = 0.2f;
    private float timer = 0f;
    
    private void Awake()
    {
        FireInput = new InputManager();
        FireInput.Player2.Shoot.performed += ctx => Fire();
    }

    private void OnEnable() 
    { 
        FireInput.Player2.Enable(); 
    }
    private void OnDisable() 
    { 
        FireInput.Player2.Disable(); 
    }

    void Update()
    {
        //Timer += Time.deltaTime;
        //if (Timer > Rate)
        //{
        //    Fire();
        //    Timer = 0f;
        //}
    }

    void Fire()
    {
        GameObject Bullet_Clone = Instantiate(Bullet, FirePoint.position, FirePoint.rotation) as GameObject;
    }
}