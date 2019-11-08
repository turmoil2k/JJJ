using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovement : MonoBehaviour
{
    public Transform[] VirtualScenes;
    public float Speed;
    public Transform CurrentScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, CurrentScene.position, Time.deltaTime * Speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, CurrentScene.rotation, Time.deltaTime * Speed);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CurrentScene = VirtualScenes[0];
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            CurrentScene = VirtualScenes[1];
        }
    }
}
