using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float timer;
    public int bulletDMG = 2;

    // Update is called once per frame
    void Update()
    {
        /*timer += Time.deltaTime;
        if (timer >= 5)
        {
            Destroy(gameObject);
            timer = 0;
        }*/

        Destroy(gameObject, 5);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Breakable_Wall")
        {
            collision.gameObject.GetComponent<WallHealth>().DamageToWall(bulletDMG);
            Destroy(gameObject);
        }
    }
}
