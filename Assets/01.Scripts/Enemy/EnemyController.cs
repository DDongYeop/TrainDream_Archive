using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : PoolableMono
{
    [SerializeField] private CommonAIState _initState;
    private CommonAIState _currentState;
    public CommonAIState CurrentState => _currentState;
    
    private AgentAnimator _agentAnimator;
    public AgentAnimator AgAnimator => _agentAnimator;

    private AgentNavMovement _agentNavMovement;
    public AgentNavMovement NavAgentMovement => _agentNavMovement;

    private EnemyHealth _enemyHealth;
    public EnemyHealth EnemyHealth => _enemyHealth;

    private EnemyAttack _enemyAttack;
    public EnemyAttack EnemyAttack => _enemyAttack;
    
    private Transform _targetTrm;
    public Transform TargetTrm => _targetTrm;
    
    private List<AITransition> _anyState = new List<AITransition>();
    public List<AITransition> AnyState => _anyState;

    [SerializeField] private EnemyDataSO _enemyData;
    public EnemyDataSO EnemyData => _enemyData;

    [SerializeField] private UnityEvent _deadEvent;
    private bool _isDead = false;
    
    private void Start()
    {
        _agentAnimator = GetComponentInChildren<AgentAnimator>();
        _agentNavMovement = GetComponent<AgentNavMovement>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyAttack = GetComponent<EnemyAttack>();
        
        _targetTrm = AgentTrainController.Instance.GetAttackTarget();
        _currentState = _initState;

        List<CommonAIState> states = new List<CommonAIState>(); 
        transform.Find("AI").GetComponentsInChildren<CommonAIState>(states);
        states.ForEach(t => t.SetUp(transform));
        
        _enemyHealth.SetMaxHp(_enemyData.MaxHP);
        Init();
    }

    private void Update()
    {
        _currentState?.UpdateState();
    }

    public override void Init()
    {
        if (_agentAnimator == null)
            return;
        
        _agentAnimator.Init();
        _enemyHealth.Init(this);
        _isDead = false;
    }

    public void ChangeState(CommonAIState state)
    {
        if (_isDead)
            return;

        CurrentState.OnExitState();
        _currentState = state;
        CurrentState.OnEnterState();
    }
    
    public void AttackWeapon(float damage, Vector3 targetDir)
    {
        _enemyAttack.Attack(damage, targetDir);
    }

    public void OnDamage(int damage, Vector3 point, Vector3 normal)
    {
        _enemyHealth.OnDamage(damage, point, normal);
    }

    public void SetDead()
    {
        _isDead = true;
        _deadEvent?.Invoke();
        _agentNavMovement.AgentStop();
        _agentAnimator.SetIsDie(true);
        Destroy(gameObject, 1.5f);
    }
}
