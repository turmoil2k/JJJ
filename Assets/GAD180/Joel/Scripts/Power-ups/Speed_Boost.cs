using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Boost : MonoBehaviour
{
    private MovementController controls;

    private float duration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        { StartCoroutine(Pick_Up(other)); }
    }

    IEnumerator Pick_Up(Collider player)
    {
        controls = player.GetComponent<MovementController>();
        controls.speed *= 2;

        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        controls.speed /= 2;

        Destroy(gameObject);
    }
}
