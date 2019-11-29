using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCamera : MonoBehaviour
{
    public List<Transform> ActiveCubes;

    public Vector3 offset;
    public float smoothTime = 0.5f;

    public float MinZoom;
    public float MaxZoom;
    public float ZoomLimiter;

    private Vector3 velocity;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {

        if (ActiveCubes.Count == 0)
        {
            return;
        }

        Move();
        Zoom();
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(MaxZoom, MinZoom, GetGreatestDistance() / ZoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
    }

    void Move()
    {
        Vector3 Center = GetCenterPoint();

        Vector3 newPosition = Center + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(ActiveCubes[0].position, Vector3.zero);

        for (int i = 0; i < ActiveCubes.Count; i++)
        {
            bounds.Encapsulate(ActiveCubes[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if(ActiveCubes.Count == 1)
        {
            return ActiveCubes[0].position;
        }

        var bounds = new Bounds(ActiveCubes[0].position, Vector3.zero);

        for (int i = 0; i < ActiveCubes.Count; i++)
        {
            bounds.Encapsulate(ActiveCubes[i].position);
        }

        return bounds.center;
    }
}
