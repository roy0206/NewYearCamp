using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private Player player;
    private State currentState;

    public void Setup(State defaultState)
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        currentState = null;

        ChangeState(defaultState);
    }

    public void Execute()
    {
        if (currentState != null) currentState.Execute(player);
    }

    public void ChangeState(State newState)
    {
        if (newState == null) return;

        currentState = newState;
        currentState.Enter(player);
    }
}
