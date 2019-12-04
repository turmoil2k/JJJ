using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerID { Player1, Player2 }

public class Firing : MonoBehaviour
{
    #region FiringSystem

    public GameObject Bullet;
    public Transform FirePoint;
    public InputManager FireInput;
    public PlayerID player;

    private void OnEnable()
    {
        FireInput.Player1.Enable();
        FireInput.Player2.Enable();
    }
    private void OnDisable()
    {
        FireInput.Player1.Disable();
        FireInput.Player2.Disable();
    }

    private void Awake()
    {
        FireInput = new InputManager();

        switch (player)
        {
            case PlayerID.Player1:
                FireInput.Player1.Shoot.performed += ctx => Fire();
                break;

            case PlayerID.Player2:
                FireInput.Player2.Shoot.performed += ctx => Fire();
                break;

            default:
                break;
        }
    }

    void Fire() 
    { GameObject Bullet_Clone = Instantiate(Bullet, FirePoint.position, FirePoint.rotation) as GameObject; }

    #endregion

    //public float firerate = 0.2f;
    //private float timer = 0f;

    void Update()
    {
        //timer += Time.deltaTime;
        //if (timer > rate)
        //{
        //    Fire();
        //    timer = 0f;
        //}
    }
}