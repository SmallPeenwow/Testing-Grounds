using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    private float xRotation = 0f;
    [SerializeField] private float xSensitivity = 30f;
    [SerializeField] private float ySensitivity = 30f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // Calculate camera rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // Apply to camera transform
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate player to look left and right
        transform.Rotate((mouseX * Time.deltaTime) * xSensitivity * Vector3.up);
    }
}
