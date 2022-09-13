using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private new Camera camera;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask layerMask;
    private PlayerUI playerUI;
    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<PlayerLook>().camera;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        // A ray at the center of the camera, shooting outwards.
        Ray ray = new(camera.transform.position, camera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo; // Store collision information

        if (Physics.Raycast(ray, out hitInfo, distance, layerMask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

                //if (interactable.GetComponent<DoorMove>()) // For door movement to be constant
                //{
                //    //Vector2 LookRotation = inputManager.onFoot.Look.ReadValue<Vector2>();

                //    //inputManager.onFoot.Interact.performed += ctx => interactable.BaseInteract();
                //    //inputManager.onFoot.Interact.canceled += ctx => interactable.GetComponent<DoorMove>().MoveDoor(LookRotation);
                //}
          
                playerUI.UpdateText(interactable.promptMessage);
                
                if (inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
