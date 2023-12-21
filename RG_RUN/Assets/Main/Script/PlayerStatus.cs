using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStatus
{
    public class Idle : State
    {
        public override void Enter(Player player)
        {
            player.speed = GameManager.instance.info.baseHp;
            player.isAllowedDamage = true;
        }
        public override void Execute(Player player)
        {

        }
        public override void Exit(Player player)
        {

        }
    }
    public class Run : State
    {
        public override void Enter(Player player)
        {
            player.speed = GameManager.instance.info.boostSpeed;
            player.isAllowedDamage = false;
            player.setTime += GameManager.instance.info.boostCoolTime;
        }
        public override void Execute(Player player)
        {

        }
        public override void Exit(Player player)
        {

        }
    }
}
