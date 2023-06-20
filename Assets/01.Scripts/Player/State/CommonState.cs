using UnityEngine;

public abstract class CommonState : MonoBehaviour, IState
{
    public abstract void OnEnterState();
    public abstract void OnExitState();
    public abstract bool UpdateState();

    protected AgentInput _agentInput;
    protected AgentMovement _agentMovement;

    public virtual void SetUp(Transform agentRoot)
    {
        _agentInput = agentRoot.GetComponent<AgentInput>();
        _agentMovement = agentRoot.GetComponent<AgentMovement>();
    }
}
