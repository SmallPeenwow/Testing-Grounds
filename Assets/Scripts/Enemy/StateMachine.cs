using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;

    public void Initialise()
    {
        // Setup default state
        ChangeState(new PatrolState());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }
    }

    public void ChangeState(BaseState newState)
    {
        // Check activeState != null
        if(activeState != null)
        {
            // Run cleanup on activeState
            activeState.Exit();
        }

        // Change to new state
        activeState = newState;

        // Fail-sfe null check to make sure new state wasn't null
        if (activeState != null)
        {
            // Setup new state
            activeState.stateMachine = this;

            // Assign state to enemy class
            activeState.enemy = GetComponent<Enemy>();

            activeState.Enter();
        }
    }
}
