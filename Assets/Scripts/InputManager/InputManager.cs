using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        Cursor.lockState = CursorLockMode.Locked;
        
        // started, canceled, performed Actions 3 states
        // Jump
        onFoot.Jump.performed += ctx => motor.Jump();

        // Crouch
        onFoot.Crouch.started += ctx => motor.Crouch();
        onFoot.Crouch.canceled += ctx => motor.Stand();
        // Sprint 
        onFoot.Sprint.started += ctx => motor.Sprint();
        onFoot.Sprint.canceled += ctx => motor.Walk();
  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Playermotor to move using the value from movement action.
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }


    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
