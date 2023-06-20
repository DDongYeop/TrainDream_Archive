using System;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class AgentController : MonoBehaviour
{
    private AudioSource _audioSource;
    private Dictionary<StateType, IState> _stateDictionary = new Dictionary<StateType, IState>();
    private IState _currentState;

    private void Awake()
    {
        Transform stateTrm = transform.Find("States");
        foreach( StateType state in Enum.GetValues(typeof (StateType)) )
        {
            IState stateScript = stateTrm.GetComponent($"{state}State") as IState;
            if(stateScript == null)
            {
                Debug.LogError($"There is no script : {state}");
                return;
            }
            stateScript.SetUp(transform);
            _stateDictionary.Add(state, stateScript);
        }

        _audioSource = GetComponent<AudioSource>();
    }
    
    private void Start()
    {
        ChangeState(StateType.Normal);
    }

    private void Update()
    {
        _audioSource.volume = Mathf.Clamp(Mathf.Abs(AgentInput.Instance.Pos.x) + Mathf.Abs(AgentInput.Instance.Pos.z), 0, 1);
    }

    public void ChangeState(StateType type)
    {
        _currentState?.OnExitState(); 
        _currentState = _stateDictionary[type];
        _currentState?.OnEnterState(); 
    }

    public void PlayerDie()
    {
        CameraManager.Instance.AddShake(7.5f, 2.5f);
        UIManager.Instance.UIShow(UIType.GameOver, true, 1);
    }
}
