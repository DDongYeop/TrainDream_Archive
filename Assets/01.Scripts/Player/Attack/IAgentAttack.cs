using UnityEngine;

public interface IAgentAttack
{
    public void Init(int damage, float coolTime, Vector3 targetPos = default);
}
