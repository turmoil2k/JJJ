﻿using System.Collections;
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
    public bool SelectShapeP1;
    public bool SelectShapeP2;
    public bool CreditsScene;
    public bool Orange;
    public bool Yellow;
    public bool Red;
    public Material OrangeCube;
    public Material YellowCube;
    public Material RedCube;
    public bool Blue;
    public bool Purple;
    public bool Green;
    public Material BlueCube;
    public Material PurpleCube;
    public Material GreenCube;
    public bool GameDemo;
    public bool FinalGame;
    public GameObject Camera;
    public GameObject Level;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu = true;
        SelectShapeP1 = false;
        SelectShapeP2 = false;

        Credits = false;
        QuitGame = false;
        StartGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, CurrentScene.position, Time.deltaTime * Speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, CurrentScene.rotation, Time.deltaTime * Speed);

        if (SelectShapeP1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CurrentScene = VirtualScenes[0];
                SelectShapeP1 = false;
                SelectShapeP2 = false;
                MainMenu = true;
            }

            if (Orange)
            {
                OrangeCube.EnableKeyword("_EMISSION");
                YellowCube.DisableKeyword("_EMISSION");
                RedCube.DisableKeyword("_EMISSION");

                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    Orange = false;
                    Yellow = false;
                    Red = true;
                }

                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    Orange = false;
                    Yellow = true;
                    Red = false;
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    StartCoroutine(Timer());
                }
            }

            if (Yellow)
            {
                OrangeCube.DisableKeyword("_EMISSION");
                YellowCube.EnableKeyword("_EMISSION");
                RedCube.DisableKeyword("_EMISSION");

                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    Orange = true;
                    Yellow = false;
                    Red = false;
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    StartCoroutine(Timer());
                }
            }

            if (Red)
            {
                OrangeCube.DisableKeyword("_EMISSION");
                YellowCube.DisableKeyword("_EMISSION");
                RedCube.EnableKeyword("_EMISSION");

                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    Orange = true;
                    Yellow = false;
                    Red = false;
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    StartCoroutine(Timer());
                }
            }
        }

        if (SelectShapeP2)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CurrentScene = VirtualScenes[1];
                SelectShapeP1 = true;
                SelectShapeP2 = false;
            }

            if (Blue)
            {
                BlueCube.EnableKeyword("_EMISSION");
                PurpleCube.DisableKeyword("_EMISSION");
                GreenCube.DisableKeyword("_EMISSION");

                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    Blue = false;
                    Purple = false;
                    Green = true;
                }

                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    Blue = false;
                    Purple = true;
                    Green = false;
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Debug.Log("Game Started");
                    GameDemo = true;

                    if(GameDemo)
                    {
                        Camera.SetActive(false);
                        Level.SetActive(true);
                    }

                    if (FinalGame)
                    {

                    }
                }
            }

            if (Purple)
            {
                BlueCube.DisableKeyword("_EMISSION");
                PurpleCube.EnableKeyword("_EMISSION");
                GreenCube.DisableKeyword("_EMISSION");

                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    Blue = true;
                    Purple = false;
                    Green = false;
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Debug.Log("Game Started");
                }
            }

            if (Green)
            {
                BlueCube.DisableKeyword("_EMISSION");
                PurpleCube.DisableKeyword("_EMISSION");
                GreenCube.EnableKeyword("_EMISSION");

                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    Blue = true;
                    Purple = false;
                    Green = false;
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Debug.Log("Game Started");
                }
            }
        }


        if (CreditsScene)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CurrentScene = VirtualScenes[0];
                MainMenu = true;
                CreditsScene = false;
            }
        }

        if (MainMenu)
        {
            if (Credits)
            {
                YMaterial.EnableKeyword("_EMISSION");
                RMaterial.DisableKeyword("_EMISSION");
                GMaterial.DisableKeyword("_EMISSION");

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    CurrentScene = VirtualScenes[3];

                    CreditsScene = true;
                    MainMenu = false;
                }

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
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#endif
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
                    SelectShapeP1 = true;

                    Orange = false;
                    Green = false;
                    Red = true;

                    MainMenu = false;
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

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1/10);

        CurrentScene = VirtualScenes[2];

        SelectShapeP1 = false;
        SelectShapeP2 = true;
        Green = true;
        MainMenu = false;
    }
}
