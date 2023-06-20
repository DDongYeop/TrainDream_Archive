using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAIState : CommonAIState
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _damage;
    private bool _isActive = false;
    private Vector3 _targetVector;
    
    private float _atkMotionDelay = 0.2f;

    [SerializeField] private float _atkCoolTime = 1f;
    private float _lastAtkTime = 0;
    
    public override void OnEnterState()
    {
        _enemyController.NavAgentMovement.AgentStop();
        
        _enemyController.AgAnimator.OnAnimationEventTrigger += AttackCollisionHandle;
        _enemyController.AgAnimator.OnAnimationEndTrigger += AttackAnimationEndHandle;
        
        _isActive = true;
    }

    public override void OnExitState()
    {
        _enemyController.AgAnimator.OnAnimationEventTrigger -= AttackCollisionHandle;
        _enemyController.AgAnimator.OnAnimationEndTrigger -= AttackAnimationEndHandle;
        
        _isActive = false;
    }

    private void AttackCollisionHandle()
    {
        _enemyController.AttackWeapon(_damage, _targetVector);
    }

    private void AttackAnimationEndHandle()
    {
        _lastAtkTime = Time.time;
        
        _enemyController.AgAnimator.SetIsAttack(false);
        
        MonoFunction.Instance.AddCoroutine(() =>
        {
            _aiActionData.IsAttacking = false;
        }, _atkMotionDelay);
    }

    public override bool UpdateState()
    {
        if( base.UpdateState())
        {
            return true;
        }
        
        if (_aiActionData.IsAttacking == false && _isActive)
        {
            SetTarget(); //타겟을 향하도록 벡터 만들어주고
            //여기서 원래 로테이션 스피드에 맞춰 돌아야 하는데 

            Vector3 currentFrontVector = transform.forward; //캐릭터의 전방으로 
            float angle = Vector3.Angle(currentFrontVector, _targetVector);

            if (angle >= 10f)
            {
                Vector3 result = Vector3.Cross(currentFrontVector, _targetVector);

                float sign = result.y > 0 ? 1 : -1;
                _enemyController.transform.rotation = Quaternion.Euler(0, sign * _rotateSpeed * Time.deltaTime, 0) * _enemyController.transform.rotation;
            }
            else if(_lastAtkTime + _atkCoolTime < Time.time )
            {
                _aiActionData.IsAttacking = true;
                _enemyController.AgAnimator.SetAttack();
                _enemyController.AgAnimator.SetIsAttack(true);
            }
            
        }
        return false;
    }
    
    private void SetTarget()
    {
        _targetVector = _enemyController.TargetTrm.position - transform.position;
        _targetVector.y = 0; 
    }
}
