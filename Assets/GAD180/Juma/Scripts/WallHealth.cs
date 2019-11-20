using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour
{
    public int health = 10;
    public float timer;
    public GameObject accessRespawnScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            accessRespawnScript.GetComponent<WallController>().wallBool = false;
        }
    }

    public void DamageToWall(int bulletDMG)
    {
        health -= bulletDMG;
    }

    public void HealthRestore(int addHealth)
    {
        health += addHealth;
    }
}

