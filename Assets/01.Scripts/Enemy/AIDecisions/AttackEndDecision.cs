public class AttackEndDecision : AIDecision
{
    public override bool MakeADecision()
    {
        return !_aiActionData.IsAttacking;
    }
}
