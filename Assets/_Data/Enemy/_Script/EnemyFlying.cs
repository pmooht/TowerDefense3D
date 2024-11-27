using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlying : EnemyMoving
{
    protected override void LoadMovingStatus()
    {
        this.isMoving = !this.ctrl.Agent.isStopped;
        this.ctrl.Animator.SetBool("isFlying", this.isMoving);
    }
}
