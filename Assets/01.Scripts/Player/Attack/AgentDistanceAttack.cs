using System.Collections;
using UnityEngine;

public class AgentDistanceAttack : MonoBehaviour, IAgentAttack
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _spawnPositon;
    [SerializeField] private LayerMask _whatIsEnemy;
    [SerializeField] private float _maxDistance;
    private int _damage;
    private float _coolTime;
    
    public void Init(int damage, float coolTime, Vector3 targetPos = default)
    {
        _damage = damage;
        _coolTime = coolTime;

        StopAllCoroutines();
        StartCoroutine(SpawnProjectile());
    }

    private IEnumerator SpawnProjectile()
    {
        while (true)
        {
            yield return new WaitForSeconds(_coolTime);
            GameObject projectile = Instantiate(_projectile, _spawnPositon.position, Quaternion.identity);
            projectile.GetComponent<IAgentAttack>().Init(_damage, _coolTime, NearEnemy());
        }
    }

    private Vector3 NearEnemy()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, _maxDistance, _whatIsEnemy);
        Vector3 minObj = _spawnPositon.position + Vector3.down;
        
        if (enemies.Length < 1)
            return minObj;
        
        float minDestance = int.MaxValue;
        float distance;
        
        foreach (Collider enemy in enemies)
        {
            distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (minDestance > distance)
            {
                minDestance = distance;
                minObj = enemy.transform.position;
            }
        }
        
        return minObj;
    }
}
