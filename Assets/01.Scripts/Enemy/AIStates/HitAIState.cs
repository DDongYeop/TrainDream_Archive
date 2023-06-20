using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAIState : CommonAIState
{
    public override void OnEnterState()
    {
        _enemyController.AgAnimator.SetHit();
    }

    public override void OnExitState()
    {
    }

    public override bool UpdateState()
    {
        return base.UpdateState();
    }
}
