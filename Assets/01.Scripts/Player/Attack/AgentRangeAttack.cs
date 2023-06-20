using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRangeAttack : MonoBehaviour, IAgentAttack
{
    private int _damage;
    
    public void Init(int damage, float coolTime, Vector3 targetPos = default)
    {
        _damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            other.transform.GetComponent<EnemyController>().OnDamage(_damage, Vector3.zero, Vector3.zero);
    }
}
