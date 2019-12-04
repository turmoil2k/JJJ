using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody RB;
    public InputManager MoveInput;

    public Vector2 movement;
    Vector3 inputDirection;

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
    }

    private void Awake()
    {
        MoveInput.Player1.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        float horizontal = movement.x;
        float vertical = movement.y;
        
        var targetInput = new Vector3(horizontal, 0, vertical);
        inputDirection = Vector3.Lerp(inputDirection, targetInput, Time.deltaTime * 10f);
    }
}
