using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected State currentState;

    void Update()
    {
        currentState.OnStateFixedUpdate();
    }

    public void ChangeState(State newState)
    {
        currentState.OnStateExit();
        currentState = newState;
        currentState.OnStateEnter();
    }
}
