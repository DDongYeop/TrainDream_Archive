using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSupportAttack : MonoBehaviour, IAgentAttack
{
    private Action<int> _addIndex;
    private int addAmount = 0;

    private void Start()
    {
        _addIndex += GameObject.Find("ExperienceBar").GetComponent<ExperienceBar>().SupportExperience;
        _addIndex += transform.root.GetComponent<AgentHealth>().AddHP;
    }

    private void Update()
    {
        _addIndex?.Invoke(addAmount);
    }

    public void Init(int damage, float coolTime, Vector3 targetPos = default)
    {
        ++addAmount;
    }
}
