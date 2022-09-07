using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightShoulder : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    private bool flashLightActive = false;

    // Start is called before the first frame update
    void Start()
    {
        flashlight.SetActive(false);
    }

    public void ToggleFlashLight()
    {
        flashLightActive = !flashLightActive;
        flashlight.SetActive(flashLightActive);
    }
}
