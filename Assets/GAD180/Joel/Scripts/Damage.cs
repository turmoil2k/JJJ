using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject player;
    public GameObject cam1, cam2;
    Restart rs;

    public float health = 100;

    public void TakeDamage(float damageAmt) 
    { health -= damageAmt; }

    private void Start()
    {
        rs = FindObjectOfType<Restart>();
    }

    public void Update() 
    {
        if (health <= 0)
        {
            player.SetActive(false);

            if (player.CompareTag("Player"))
            {
                rs.gameOver = true;
                cam1.SetActive(true);
            }

            else if (player.CompareTag("Player2"))
            {
                rs.gameOver = true;
                cam2.SetActive(true);
            }

        }

    }

}