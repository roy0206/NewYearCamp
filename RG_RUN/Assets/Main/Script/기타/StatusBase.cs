using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void Enter(Controller plr);
    public abstract void Execute(Controller plr);
    public abstract void Exit(Controller plr);

}
