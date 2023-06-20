public class ChaseAIState : CommonAIState
{
    public override void OnEnterState()
    {
    }

    public override void OnExitState()
    {
    }

    public override bool UpdateState()
    {
        //움직이는거 실행.
        _enemyController.NavAgentMovement.AgentTargetSet(_enemyController.TargetTrm);
        
        return base.UpdateState();
    }
}
