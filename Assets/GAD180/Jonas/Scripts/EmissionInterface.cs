using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionInterface : MonoBehaviour
{
    public bool Credits; //credits
    public bool QuitGame; //quit
    public bool StartGame; //start
    public Material YMaterial;
    public Material RMaterial;
    public Material GMaterial;

    // Start is called before the first frame update
    void Start()
    {
        Credits = false;
        QuitGame = false;
        StartGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Credits)
        {
            YMaterial.EnableKeyword("_EMISSION");
            RMaterial.DisableKeyword("_EMISSION");
            GMaterial.DisableKeyword("_EMISSION");

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                Credits = false;
                QuitGame = false;
                StartGame = true;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                Credits = false;
                QuitGame = true;
                StartGame = false;
            }
        }

        if (QuitGame)
        {
            YMaterial.DisableKeyword("_EMISSION");
            RMaterial.EnableKeyword("_EMISSION");
            GMaterial.DisableKeyword("_EMISSION");

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                Credits = true;
                QuitGame = false;
                StartGame = false;
            }
        }

        if (StartGame)
        {
            YMaterial.DisableKeyword("_EMISSION");
            RMaterial.DisableKeyword("_EMISSION");
            GMaterial.EnableKeyword("_EMISSION");

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                Credits = true;
                QuitGame = false;
                StartGame = false;
            }
        }
    }
}
