using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Boost : MonoBehaviour
{
    public PlayerStats damage;
    
    public float duration = 10f;

    private void OnTriggerEnter(Collider other)
    {
        { StartCoroutine(Pick_Up(other)); }
    }

    IEnumerator Pick_Up(Collider player)
    {
        damage.DamageAmt *= 2;

        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        damage.DamageAmt /= 2;

        Destroy(gameObject);
    }
}
