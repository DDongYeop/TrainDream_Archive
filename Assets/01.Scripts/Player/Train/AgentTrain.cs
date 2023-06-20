using UnityEngine;

public class AgentTrain : MonoBehaviour
{
    private AgentTrainController _trainController;
    public int TrainIndex;

    public void Init(AgentTrainController trainController, TrainType type, int damage, float coolTime)
    {
        this._trainController = trainController;
        
        GameObject visual = Instantiate(this._trainController.TrainDatas[(int)type].Visual, transform, false);
        visual.GetComponentInChildren<IAgentAttack>().Init(damage, coolTime);

        // Type에 맞게 Visual 변경, 이미지 생성 
    }
}
