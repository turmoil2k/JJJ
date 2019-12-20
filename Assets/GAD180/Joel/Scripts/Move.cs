using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody RB1;
    private Rigidbody RB2;
    public InputManager MoveInput;

    public int speed = 10;
    public float maxSpeed = 30;
    public Vector2 movementP1;
    public Vector2 movementP2;

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
        RB1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        RB2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody>();
        RB1.constraints = RigidbodyConstraints.FreezeRotation;
        RB2.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Awake()
    {
        MoveInput = new InputManager();
        
        MoveInput.Player1.Move.performed += ctx => movementP1 = ctx.ReadValue<Vector2>();
        MoveInput.Player1.Move.canceled += ctx => movementP1 = Vector2.zero;

        MoveInput.Player2.Move.performed += ctx => movementP2 = ctx.ReadValue<Vector2>();
        MoveInput.Player2.Move.canceled += ctx => movementP2 = Vector2.zero;
    }

    private void Update()
    {
        MoveP1();
        MoveP2();
    }

    private void MoveP1()
    {
        Vector3 move_pos = new Vector3(-movementP1.y, 0, movementP1.x) * speed;
        RB1.velocity += move_pos;

        RB1.transform.forward += RB1.velocity;
        RB1.transform.LookAt(RB1.transform.position + ((RB1.velocity.magnitude > 0) ? RB1.velocity : RB1.transform.forward), Vector3.up);
        Vector3 dir = RB1.transform.eulerAngles;
        dir.x = 0;
        RB1.transform.eulerAngles = dir;

        if (RB1.velocity.magnitude >= maxSpeed) { RB1.velocity = RB1.velocity.normalized * maxSpeed; }
    }

    private void MoveP2()
    {
        Vector3 move_pos = new Vector3(movementP2.y, 0, -movementP2.x) * speed;
        RB2.velocity += move_pos;

        RB2.transform.forward += RB2.velocity;
        RB2.transform.LookAt(RB2.transform.position + ((RB2.velocity.magnitude > 0) ? RB2.velocity : RB2.transform.forward), Vector3.up);
        var dir = RB2.transform.eulerAngles;
        dir.x = 0;
        RB2.transform.eulerAngles = dir;

        if (RB2.velocity.magnitude >= maxSpeed) { RB2.velocity = RB2.velocity.normalized * maxSpeed; }
    }
}
