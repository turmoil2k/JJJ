using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerStats player;
    private A_Firing fire;

    private float speed = 20f;
    //public float lifetime = 2f;

    void Start()
    {
        Rigidbody RB = GetComponent<Rigidbody>();
        RB.velocity = transform.forward * fire.m_CurrentForce;
        //Invoke("Destroy_Bullet", lifetime);
    }
    private void OnTriggerEnter(Collider onHit)
    {
        Damage damage = onHit.GetComponent<Damage>();
        //float Hit_Distance = Vector3.Distance(onHit.transform.position, gameObject.transform.position);

        //if (Hit_Distance >= 5f)
        {
            if (damage != null) { damage.TakeDamage(player.DamageAmt); }
        }

        Destroy(gameObject);
    }

    private void Destroy_Bullet() { Destroy(gameObject); }
}