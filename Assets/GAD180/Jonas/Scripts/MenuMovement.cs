using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public enum playerColor
{
    color1,color2,color3
}

public class MenuMovement : MonoBehaviour
{
    public playerColor player1Color, Player2Color;
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
    public bool PlayerIsRed;
    public bool PlayerIsOrange;
    public bool PlayerIsYellow;
    public bool PlayerIsGreen;
    public bool PlayerIsBlue;
    public bool PlayerIsPurple;
    public MeshRenderer p1, p2;
    public TrailRenderer p1t, p2t;
    public Material yellow, red, blue, orange, green, purple;
    public Material yellowt, redt, bluet, oranget, greent, purplet;

    //public InputManager Inputs;

    //private void OnEnable() { Inputs.Menu.Enable(); }

    //private void OnDisable() { Inputs.Menu.Disable(); }

    private void Awake()
    {
       // Inputs.Menu.Move.performed += ctx => { Debug.Log("bib"); MenuMove = ctx.ReadValue<Vector2>(); };
       // Inputs.Menu.Down.performed += ctx => Debug.Log("test");
    }

    // Start is called before the first frame update
    void Start()
    {
        MainMenu = true;
        SelectShapeP1 = false;
        SelectShapeP2 = false;

        Credits = false;
        QuitGame = false;
        StartGame = true;

        PlayerIsRed = false;
        PlayerIsOrange = false;
        PlayerIsYellow = false;
        PlayerIsGreen = false;
        PlayerIsBlue = false;
        PlayerIsPurple = false;

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
                    PlayerIsOrange = true;

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
                    PlayerIsYellow = true;

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
                    PlayerIsRed = true;

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
                    PlayerIsBlue = true;
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
                    PlayerIsPurple = true;
                    GameDemo = true;

                    if (GameDemo)
                    {
                        Camera.SetActive(false);
                        Level.SetActive(true);
                    }
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
                    PlayerIsGreen = true;
                    GameDemo = true;

                    if (GameDemo)
                    {
                        Camera.SetActive(false);
                        Level.SetActive(true);
                    }
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

        if (PlayerIsRed)
        {
            p1.material = red;
            p1t.material = redt;
        }

        if (PlayerIsOrange)
        {
            p1.material = orange;
            p1t.material = oranget;

        }

        if (PlayerIsYellow)
        {
            p1.material = yellow;
            p1t.material = yellowt;
        }

        if (PlayerIsGreen)
        {
            p2.material = green;
            p2t.material = greent;
        }

        if (PlayerIsBlue)
        {
            p2.material = blue;
            p2t.material = bluet;
        }

        if (PlayerIsPurple)
        {
            p2.material = purple;
            p2t.material = purplet;
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
