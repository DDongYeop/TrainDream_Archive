public class FallDecisions : AIDecision
{
    public override bool MakeADecision()
    {
        return _enemyController.NavAgentMovement.IsFall();
    }
}
