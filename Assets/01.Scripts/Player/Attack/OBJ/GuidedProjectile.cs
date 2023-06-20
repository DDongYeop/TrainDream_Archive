using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedProjectile : MonoBehaviour, IAgentAttack
{
    [Header("Basic")]
    private int _damage;

    [Header("Movement")] 
    [SerializeField] private float _moveSpeed;
    
    [Header("Rotation")] 
    [SerializeField] private bool _isRotation;
    [SerializeField] private float _rotationValue;

    private void Update()
    {
        if (_isRotation)
            transform.Rotate(Vector3.up * (Time.deltaTime * _rotationValue));

        transform.position += transform.forward * (_moveSpeed * Time.deltaTime);
    }

    public void Init(int damage, float coolTime = 0, Vector3 targetPos = default)
    {
        _damage = damage;
        transform.LookAt(targetPos);

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
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
