using UnityEngine;

public class NormalState : CommonState
{
    public override void OnEnterState()
    {
        _agentInput.PlayerMoveEvent += OnAttackHandle;
    }

    public override void OnExitState()
    {
        _agentInput.PlayerMoveEvent -= OnAttackHandle;
    }

    private void OnAttackHandle(Vector3 pos)
    {
        _agentMovement.SetMovePosition(pos);
    }

    public override bool UpdateState()
    {
        return true;
    }
}
