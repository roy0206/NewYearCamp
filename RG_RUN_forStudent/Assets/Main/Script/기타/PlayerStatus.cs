using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStatus
{
    public class Idle : State
    {
        public override void Enter(Controller con)
        {
            Time.timeScale = 1;
        }
        public override void Execute(Controller con)
        {

        }
        public override void Exit(Controller con)
        {

        }
    }
    public class Run : State
    {
        public override void Enter(Controller con)
        {
            Time.timeScale = GameManager.instance.info.boostSpeed / GameManager.instance.info.baseSpeed;
            con.setTime += GameManager.instance.info.boostCoolTime;
        }
        public override void Execute(Controller con)
        {

        }

        public override void Exit(Controller con)
        {

        }
    }
}
