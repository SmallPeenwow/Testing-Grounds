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
                //    float yRot = 0.0f; // rotation around the up/y axis
                //    float mouseY = -Input.GetAxis("Mouse Y");
                //    float mouseX = Input.GetAxis("Mouse X");
                //    //rotY += mouseX * inputManager.GetComponent<PlayerLook>().xSensitivity * Time.deltaTime * Vector3.up;
                //    //Vector2 LookRotation = inputManager.onFoot.Look.ReadValue<Vector2>();
                //    //var v = GameObject.Find(hitInfo.collider.gameObject.name).transform.position.y;
                //    //Vector3 mousePos = Input.mousePosition;
                //    //Debug.Log((mouseX * Time.deltaTime) * inputManager.GetComponent<PlayerLook>().xSensitivity * Vector3.up);
                //    //Quaternion localRotation = Quaternion.Euler(0f, rotY, 0.0f);
                //    //hitInfo.collider.transform.Rotate((mouseX * Time.deltaTime) * inputManager.GetComponent<PlayerLook>().xSensitivity * Vector3.up);
                //    //hitInfo.collider.transform.rotation = localRotation;

                //    yRot += Input.GetAxis("Mouse Y") * inputManager.GetComponent<PlayerLook>().ySensitivity * Time.deltaTime;
                //    Debug.Log(yRot * 1000 + " First");
                //    yRot = Mathf.Clamp(0, yRot, 0);
                //    Debug.Log(yRot);
                //    hitInfo.collider.transform.rotation = Quaternion.Euler(0.0f, yRot * 1000, 0.0f);

                //    inputManager.onFoot.Interact.started += ctx => interactable.BaseInteract();
                //    inputManager.onFoot.Interact.canceled += ctx => interactable.BaseInteract();
                //    hitInfo.collider.transform.rotation = Quaternion.Euler(new Vector3(0, mousePos.y, 0));
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
