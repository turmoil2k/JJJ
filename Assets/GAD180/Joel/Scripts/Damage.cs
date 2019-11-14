using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject Player;
    public GameObject EnemyA;

    public float Health = 100;

    public void TakeDamage(float DamageAmt)
    {
        Health -= DamageAmt;
        if (Health <= 0) { Destroy(EnemyA); }
    }
}