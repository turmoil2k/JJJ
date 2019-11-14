using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;

    void Start()
    {
        Rigidbody RB = GetComponent<Rigidbody>();
        RB.velocity = transform.forward * speed;
        Invoke("Destroy_Bullet", lifetime);
    }
    private void OnTriggerEnter(Collider onHit)
    {
        Damage n_damage = onHit.GetComponent<Damage>();
        //float Hit_Distance = Vector3.Distance(onHit.transform.position, gameObject.transform.position);

        //if (Hit_Distance >= 5f)
        {
            if (n_damage != null) { n_damage.TakeDamage(20); }
        }
        Destroy(gameObject);
    }

    private void Destroy_Bullet()
    {
        Destroy(gameObject);
    }
}