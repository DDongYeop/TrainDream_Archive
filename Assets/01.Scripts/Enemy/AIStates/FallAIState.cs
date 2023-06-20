public class FallAIState : CommonAIState
{
    public override void OnEnterState()
    {
        _enemyController.AgAnimator.SetIsFall(true);
        _enemyController.NavAgentMovement.ControllModeSet(true);
    }

    public override void OnExitState()
    {
        _enemyController.AgAnimator.SetIsFall(false);
        _enemyController.NavAgentMovement.ControllModeSet(false);
    }

    public override bool UpdateState()
    {
        return base.UpdateState();
    }
}
