using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://stackoverflow.com/questions/37129162/open-a-door-front-and-back-in-unity3d-similar-to-amnesia // Code for moving doors

public class DoorMove : Interactable
{
    private bool doorState = false;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    protected override void Interact()
    {
        doorState = !doorState;
    }
}
