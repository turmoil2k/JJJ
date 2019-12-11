using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
                FireInput.Player1.Shoot.performed += Fire;
                break;

            case PlayerID.Player2:
                FireInput.Player2.Shoot.performed += Fire;
                break;

            default:
                break;
        }
    }

    void Fire(InputAction.CallbackContext context) 
    { GameObject Bullet_Clone = Instantiate(Bullet, FirePoint.position, FirePoint.rotation) as GameObject; }

    #endregion
}