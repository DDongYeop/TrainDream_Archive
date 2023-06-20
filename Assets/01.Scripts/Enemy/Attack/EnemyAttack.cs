using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    private AIActionData _enemyData;

    protected virtual void Awake()
    {
        _enemyData = transform.Find("AI").GetComponent<AIActionData>();
    }

    public abstract void Attack(float damage, Vector3 targetVector);

    public abstract void PreAttack();

    public abstract void CancelAttack();
}
