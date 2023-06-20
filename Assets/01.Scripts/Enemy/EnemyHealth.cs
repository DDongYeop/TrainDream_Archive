using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    private EnemyController _enemyController; 
    private float _maxHp;
    private float _currentHp;
    public float CurrentHP => _currentHp;

    public void SetMaxHp(float hp)
    {
        _maxHp = _currentHp = hp;
    }
    
    public void OnDamage(int damage, Vector3 point, Vector3 normal)
    {
        _currentHp -= damage;
        
        if (_currentHp <= 0)
            _enemyController.SetDead();
    }

    public void Init(EnemyController enemyController)
    {
        _currentHp = _maxHp;
        _enemyController = enemyController;
    }
}
