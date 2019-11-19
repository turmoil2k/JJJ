using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Boost : MonoBehaviour
{
    private float duration = 2f;
    private MovementController controls1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { StartCoroutine(Pick_Up(other)); }
    }

    IEnumerator Pick_Up(Collider player)
    {
        controls1 = player.GetComponent<MovementController>();
        controls1.speed *= 2;
        //controls2.speed *= 2;

        yield return new WaitForSeconds(duration);

        controls1.speed /= 2;
        //controls2.speed /= 2;

        Destroy(gameObject);
    }
}
