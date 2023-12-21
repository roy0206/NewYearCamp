using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void Enter(Player plr);
    public abstract void Execute(Player plr);
    public abstract void Exit(Player plr);

}
