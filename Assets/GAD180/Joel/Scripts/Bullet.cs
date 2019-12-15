using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerStats player;

    private float speed = 30f;
    public float lifetime = 2f;

    void Start()
    {
        Rigidbody RB = GetComponent<Rigidbody>();
        RB.velocity = transform.forward * speed;
        Invoke("Destroy_Bullet", lifetime);
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