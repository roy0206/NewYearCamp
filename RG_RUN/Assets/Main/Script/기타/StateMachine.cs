using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private Controller con;
    private State currentState;

    public void Setup(State defaultState)
    {
        con = GameObject.FindWithTag("Player").GetComponent<Controller>();
        currentState = null;

        ChangeState(defaultState);
    }

    public void Execute()
    {
        if (currentState != null) currentState.Execute(con);
    }

    public void ChangeState(State newState)
    {
        if (newState == null) return;

        currentState = newState;
        currentState.Enter(con);
    }
}
