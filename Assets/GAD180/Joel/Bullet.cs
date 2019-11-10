using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int Dmg_val = 20;

    void Start()
    {
        Rigidbody RB = this.GetComponent<Rigidbody>();
        RB.velocity = transform.forward * speed;
      // wait();
    }
    private void OnTriggerEnter(Collider onHit)
    {
        Damage n_damage = onHit.GetComponent<Damage>();
        if (n_damage != null) { n_damage.TakeDamage(Dmg_val); }
        Destroy(gameObject);
    }

    //void IEnumerator wait()
    //{

    //}

}
