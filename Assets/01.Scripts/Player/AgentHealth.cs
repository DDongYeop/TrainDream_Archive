using UnityEngine;
using UnityEngine.Events;

public class AgentHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private UnityEvent _playerDie;
    [SerializeField] private ParticleSystem _fireParticle;
    [SerializeField] private float _maxHP; //차후엔 SO에서 가져오면 좋을 듯. 
    private float _currentHp;
    public float CurrentHp => _currentHp;

    private void Awake()
    {
        _currentHp = _maxHP;
    }

    public void OnDamage(int damage, Vector3 point, Vector3 normal)
    {
        _currentHp -= damage;

        if (CurrentHp <= 0)
        {
            Debug.Log("Player die");
            _playerDie?.Invoke();
            _currentHp = 0;
        }
        FireParticle();
    }

    public void AddMaxHP(float hp)
    {
        _maxHP = hp;
        _currentHp += hp;

        Mathf.Clamp(_currentHp, 0, _maxHP);
    }

    private void FireParticle()
    {
        float index = (_maxHP - CurrentHp) / _maxHP * 50;
        index = Mathf.Clamp(index, 0, 100f);
        
        var fireParticleEmission = _fireParticle.emission;
        fireParticleEmission.rateOverTime = index;
    }

    public void AddHP(int index)
    {
        _currentHp += Time.deltaTime * index * 0.1f;
        Mathf.Clamp(_currentHp, 0, _maxHP);
    }
}
