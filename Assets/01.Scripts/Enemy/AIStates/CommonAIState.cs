using System.Collections.Generic;
using UnityEngine;

public abstract class CommonAIState : MonoBehaviour, IState
{
    protected List<AITransition> _transitions = new List<AITransition>();
    protected EnemyController _enemyController;
    protected AIActionData _aiActionData;
    
    public abstract void OnEnterState();
    public abstract void OnExitState();

    public void SetUp(Transform agentRoot)
    {
        _transitions = new List<AITransition>();
        transform.GetComponentsInChildren<AITransition>(_transitions);
        
        _enemyController = agentRoot.GetComponent<EnemyController>();
        _aiActionData = agentRoot.Find("AI").GetComponent<AIActionData>();
        
        _transitions.ForEach(t => t.SetUp(agentRoot));
    }

    public virtual bool UpdateState()
    {
        foreach (var t in _transitions)
        {
            if (t.CheckTransition())
            {
                _enemyController.ChangeState(t.NextState);
                return true;
            }
        }
        
        foreach (var t in _enemyController.AnyState)
        {
            if (t.CheckTransition())
            {
                _enemyController.ChangeState(t.NextState);
                return true;
            }
        }
        
        return false;
    }
}
