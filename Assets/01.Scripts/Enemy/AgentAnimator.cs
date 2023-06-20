using System;
using UnityEngine;

public class AgentAnimator : MonoBehaviour
{
    private readonly int _hitHash = Animator.StringToHash("Hit");
    private readonly int _attackHash = Animator.StringToHash("Attack");
    private readonly int _isAttackHash = Animator.StringToHash("IsAttack");
    private readonly int _IsVictoryHash = Animator.StringToHash("IsVictory");
    private readonly int _isDieHash = Animator.StringToHash("IsDie");
    private readonly int _isFallHash = Animator.StringToHash("IsFall");

    public event Action OnAnimationEventTrigger = null;
    public event Action OnAnimationEndTrigger = null;
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Init()
    {
        SetIsVictory(false);
        SetIsDie(false);
        SetIsFall(false);
    }

    public void SetHit()
    {
        _animator.SetTrigger(_hitHash);
    }

    public void SetAttack()
    {
        _animator.SetTrigger(_attackHash);
    }
    
    public void SetIsAttack(bool value)
    {
        _animator.SetBool(_isAttackHash, value);
    }

    public void SetIsVictory(bool value)
    {
        _animator.SetBool(_IsVictoryHash, value);
    }

    public void SetIsDie(bool value)
    {
        _animator.SetBool(_isDieHash, value);
    }
    
    public void SetIsFall(bool value)
    {
        _animator.SetBool(_isFallHash, value);
    }

    public void OnAnimationEvent()
    {
        OnAnimationEventTrigger?.Invoke();
    }

    public void OnAnimationEnd()
    {
        OnAnimationEndTrigger?.Invoke();
    }
}
