using System;
using UnityEngine;

public class AgentMeleeAttack : MonoBehaviour, IAgentAttack
{
    private int _damage;
    
    public void Init(int damage, float coolTime = 0, Vector3 targetPos = default)
    {
        _damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy") && AgentInput.Instance.Pos != Vector3.zero)
        {
            other.transform.GetComponent<EnemyController>().OnDamage(_damage, Vector3.zero, Vector3.zero);
        }
    }
}
