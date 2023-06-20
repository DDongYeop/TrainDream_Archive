using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWoodAttack : MonoBehaviour, IAgentAttack
{
    [SerializeField] private GameObject _wood;
    
    private int _damage;
    private float _coolTime;
    
    public void Init(int damage, float coolTime, Vector3 targetPos = default)
    {
        _damage = damage;
        _coolTime = coolTime;
        
        StopAllCoroutines();
        StartCoroutine(SpawnWood());
    }

    private IEnumerator SpawnWood()
    {
        while (true)
        {
            yield return new WaitForSeconds(_coolTime);
            GameObject rightWood = Instantiate(_wood);
            rightWood.transform.position = transform.position;
            rightWood.transform.rotation = Quaternion.Euler(0, transform.root.transform.eulerAngles.y, 0);
            GameObject leftWood = Instantiate(_wood);
            leftWood.transform.position = transform.position;
            leftWood.transform.rotation = Quaternion.Euler(0, 180 + transform.root.transform.eulerAngles.y, 0);
            
            rightWood.GetComponent<IAgentAttack>().Init(_damage, 1);
            leftWood.GetComponent<IAgentAttack>().Init(_damage, 0);
        }
    }
}
