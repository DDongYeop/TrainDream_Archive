using System.Collections;
using UnityEngine;

public class AgentOilAttack : MonoBehaviour, IAgentAttack
{
    private ParticleSystem _particle;
    private int _damage;
    private float _coolTime;

    private void Start()
    {
        _particle = GetComponent<ParticleSystem>();
    }

    public void Init(int damage, float coolTime, Vector3 targetPos = default)
    {
        _damage = damage;
        _coolTime = coolTime;
        
        StopAllCoroutines();
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(_coolTime);
            _particle.Play();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        print(other.name);
        if (other.CompareTag("Enemy"))
            other.transform.GetComponent<EnemyController>().OnDamage(_damage, Vector3.zero, Vector3.zero);
    }
}
