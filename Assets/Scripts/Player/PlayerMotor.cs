using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    [Header("Sprint")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool isSprinting = false;
    [SerializeField] private float sprintDuration = 5f;
    [SerializeField] private float sprintCooldown = .5f;
    [SerializeField] private float sprintFOV = 80f;
    [SerializeField] private float sprintFOVStepTime = 10f;
    [SerializeField] private bool enableSprint = true;

    [Header("Gravity")]
    [SerializeField] private float gravity = -10.8f;

    [Header("Jump")]
    [SerializeField] private float jumpHeight = 1f;

    [Header("Crouch")]
    [SerializeField] private bool isCrouching;
    [SerializeField] private float crouchHeight = .75f;
    private Vector3 originalScale;

    [SerializeField] private Camera playerCamera;

    // Internal Variables
    private float sprintRemaining;
    private bool isSprintCooldown = false;
    private float sprintCooldownReset;
    private readonly float sprintSpeed = 8f;
    private readonly float walkSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        sprintRemaining = sprintDuration;
        sprintCooldownReset = sprintCooldown;
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isCrouching) // Crouches height down well Ctl key is held in and reduces walkSpeed
        {
            //transform.localScale = new float3(originalScale.x, crouchHeight, originalScale.z);
            transform.localScale = new Vector3(originalScale.x, crouchHeight, originalScale.z);
            Walk();
        }
        else if(!isCrouching) // Stands up to full height on release of Ctl key and brings up normal walkSpeed
        {
            //transform.localScale = new float3(originalScale.x, originalScale.y, originalScale.z);
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        }

        if (enableSprint)
        {
            SprintFunction();
        }
    }

    // Receive inputs for InputManager.cs and apply them to character controller.
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;

        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            Stand();
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Crouch()
    {
        isCrouching = true;
    }

    public void Stand()
    {
        isCrouching = false;
    }

    public void Sprint()
    {
        speed = sprintSpeed;
        isSprinting = true;
    }

    public void Walk()
    {
        speed = isCrouching ? 3.5f : walkSpeed;
        isSprinting = false;
    }

    private void SprintFunction()
    {
 
        if (isSprinting)
        {

            Stand();
            // Changes FOV of player wen sprinting
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, sprintFOV, sprintFOVStepTime * Time.deltaTime);

            // Drain sprint remaining while sprinting
            sprintRemaining -= 1 * Time.deltaTime;

            if (sprintRemaining <= 0)
            {
                isSprinting = false;
                isSprintCooldown = true;
            }
        }
        else
        {
            // Regain sprint while not sprinting
            sprintRemaining = Mathf.Clamp(sprintRemaining += 1 * Time.deltaTime, 0, sprintDuration);
            Walk();
        }

        // Handles sprint cooldown
        // When sprint remaining == 0 stops sprint ability until hitting cooldown
        if (isSprintCooldown)
        {
            speed = 5f;
            sprintCooldown -= 1 * Time.deltaTime;

            if (sprintCooldown <= 0)
            {
                isSprintCooldown = false;
            }
        }
        else
        {
            sprintCooldown = sprintCooldownReset;
        }
    }
}
