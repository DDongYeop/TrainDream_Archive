using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodRoll : MonoBehaviour, IAgentAttack
{
    [SerializeField] private float _moveSpeed;
    private int _damage;

    private void Update()
    {
        transform.Translate(Vector3.right * (_moveSpeed * Time.deltaTime));
    }

    public void Init(int damage, float coolTime, Vector3 targetPos = default)
    {
        _damage = damage;
        
        StopAllCoroutines();
        StartCoroutine(ProjectileDestroy());
    }

    private void OnTriggerEnter(Collider other)
    {
        StopAllCoroutines();
        if (other.CompareTag("Player") || other.CompareTag("Train"))
            return;
        else if (other.CompareTag("Enemy"))
            other.transform.GetComponent<EnemyController>().OnDamage(_damage, Vector3.zero, Vector3.zero);
        
        Destroy(gameObject);
    }

    private IEnumerator ProjectileDestroy()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
