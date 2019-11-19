using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject player;

    public float health = 100;

    public void TakeDamage(float damageAmt) 
    { 
        health -= damageAmt; 
    }

    public void Update()
    {
        if (health <= 0) { player.SetActive(false); }
    }
}