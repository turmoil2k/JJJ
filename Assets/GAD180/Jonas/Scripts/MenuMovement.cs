using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovement : MonoBehaviour
{
    public Transform[] VirtualScenes;
    public float Speed;
    public Transform CurrentScene;
    public bool Credits;
    public bool QuitGame;
    public bool StartGame;
    public Material YMaterial;
    public Material RMaterial;
    public Material GMaterial;
    public bool MainMenu;
    public bool SelectMenu;


    // Start is called before the first frame update
    void Start()
    {
        MainMenu = true;
        SelectMenu = false;

        Credits = false;
        QuitGame = false;
        StartGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, CurrentScene.position, Time.deltaTime * Speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, CurrentScene.rotation, Time.deltaTime * Speed);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CurrentScene = VirtualScenes[0];

            SelectMenu = false;
            MainMenu = true;

            Credits = false;
            QuitGame = false;
            StartGame = true;

        }

        if (MainMenu)
        {
            if (Credits)
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

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Application.Quit();
                }

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

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    CurrentScene = VirtualScenes[1];

                    MainMenu = false;
                    SelectMenu = true;
                }

                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    Credits = true;
                    QuitGame = false;
                    StartGame = false;
                }
            }
        }
    }
}
