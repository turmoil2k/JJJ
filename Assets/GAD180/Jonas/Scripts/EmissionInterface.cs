using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionInterface : MonoBehaviour
{
    public bool StartGame;
    public bool Credits;
    public bool QuitGame;
    public Material StartMaterial;
    public Material CreditsMaterial;
    public Material QuitMaterial;

    // Start is called before the first frame update
    void Start()
    {
        StartGame = true;
        Credits = false;
        QuitGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartGame)
        {
            StartMaterial.EnableKeyword("_EMISSION");
            CreditsMaterial.DisableKeyword("_EMISSION");
            QuitMaterial.DisableKeyword("_EMISSION");

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                StartGame = false;
                Credits = true;
                QuitGame = false;
            }
        }

        if (Credits)
        {
            StartMaterial.DisableKeyword("_EMISSION");
            CreditsMaterial.EnableKeyword("_EMISSION");
            QuitMaterial.DisableKeyword("_EMISSION");

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                StartGame = true;
                Credits = false;
                QuitGame = false;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                StartGame = false;
                Credits = false;
                QuitGame = true;
            }
        }

        if (QuitGame)
        {
            StartMaterial.DisableKeyword("_EMISSION");
            CreditsMaterial.DisableKeyword("_EMISSION");
            QuitMaterial.EnableKeyword("_EMISSION");

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                StartGame = false;
                Credits = true;
                QuitGame = false;
            }
        }

    }
}
