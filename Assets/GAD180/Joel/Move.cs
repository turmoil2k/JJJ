using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody RB;
    public InputManager MoveInput;
    public Firing fp;

    public int speed = 30;
    public float maxSpeed = 50;
    public Vector2 movement;

    private void OnEnable()
    {
        MoveInput.Player1.Enable();
        MoveInput.Player2.Enable();
    }

    private void OnDisable()
    {
        MoveInput.Player1.Disable();
        MoveInput.Player2.Disable();
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        RB.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Awake()
    {
        MoveInput = new InputManager();
        
        MoveInput.Player1.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        MoveInput.Player1.Move.canceled += ctx => movement = Vector2.zero;
    }

    private void Update()
    {
        //movement.x += ;
        
        Vector3 move_pos = new Vector3(movement.x, 0, movement.y)  * speed;
        RB.velocity += move_pos;
        
        
        
        
        
        
        
        
        
        
        
        //transform.forward = RB.velocity;
        //transform.LookAt(transform.position + ((RB.velocity.magnitude > 0) ? RB.velocity : transform.forward), Vector3.up);
        //var dir = transform.eulerAngles;
        //dir.x = 0;
        //transform.eulerAngles = dir;
        //if (RB.velocity.magnitude > maxSpeed)
        //{
        //    RB.velocity = RB.velocity.normalized * maxSpeed;
        //}
        //transform.LookAt(fp.FirePoint, RB.velocity);
    }
}
