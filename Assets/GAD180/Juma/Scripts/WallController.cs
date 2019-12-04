using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{

    public bool wallBool;
    public GameObject wall;
    public float timer;
    int addHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        wallBool = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (wallBool == true)
        {
            wall.SetActive(true);
        }
        if (wallBool == false)
        {
            wall.SetActive(false);

            timer += Time.deltaTime;
            if (timer >= 10)
            {
                wall.GetComponent<WallHealth>().HealthRestore(addHealth);
                wall.SetActive(true);
                wallBool = true;
                timer = 0;
            }
        }
    }
}
