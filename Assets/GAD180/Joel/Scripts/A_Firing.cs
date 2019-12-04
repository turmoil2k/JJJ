using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_Firing : MonoBehaviour
{
    #region Variables

    public GameObject Bullet;
    public Transform FirePoint;
    public InputManager FireInput;
    public PlayerID player;
    public PlayerStats stats;

    //public Slider m_Slider;

    public float m_MinForce = 15f;
    public float m_MaxForce = 30f;
    private float m_MaxChargetime = 0.75f;

    public float m_CurrentForce;
    private float m_FireSpeed;
    private bool m_Fired;

    #endregion

    #region Firing

    private void OnEnable()
    {
        FireInput.Player1.Enable();
        FireInput.Player2.Enable();

        m_CurrentForce = m_MinForce;
        //m_Slider.value = m_MinForce;
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
                FireInput.Player1.Shoot.performed += ctx => A_Fire();
                break;

            case PlayerID.Player2:
                FireInput.Player2.Shoot.performed += ctx => A_Fire();
                break;

            default:
                break;
        }
    }

    void A_Fire()
    {
        m_Fired = true;

        GameObject Bullet_Clone = Instantiate(Bullet, FirePoint.position, FirePoint.rotation) as GameObject;

        m_CurrentForce = m_MinForce;
    }

    #endregion

    #region Trajectory

    private void Start() { m_FireSpeed = (m_MinForce - m_MaxForce) / m_MaxChargetime; }

    private void Update()
    {
        if (m_CurrentForce >= m_MaxForce && !m_Fired) 
        {
            m_CurrentForce = m_MaxForce;
            A_Fire();
        }
        else if (Input.GetButtonDown(FireInput.ToString()))
        {
            m_Fired = false;
            m_CurrentForce = m_MinForce;
        }
        else if(Input.GetButton(FireInput.ToString()))
        {
            m_CurrentForce += m_FireSpeed * Time.deltaTime;
            //m_Slider.value = m_CurrentForce;
        }
        else if(Input.GetButtonUp(FireInput.ToString()))
        { A_Fire(); }
    }

    #endregion
}
