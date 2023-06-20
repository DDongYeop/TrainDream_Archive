using System.Collections.Generic;
using UnityEngine;

public class AgentTrainController : MonoBehaviour
{
    public static AgentTrainController Instance; 
    
    public List<AgentTrain> Trains = new List<AgentTrain>();
    public List<TrainData> TrainDatas = new List<TrainData>();
    public int CurrentTrainIndex = 0;
    private int _attackIndex = 0;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple AgentTrainController is running");
        Instance = this;
    }

    private void Start()
    {
        TailDie(0);
        AddTrain(TrainType.HEAD);
    }

    public void TailDie(int index)
    {
        for (int i = index; i < Trains.Count; ++i)
            Trains[i].gameObject.SetActive(false);
        --CurrentTrainIndex;
    }

    public void AddTrain(TrainType type)
    {
        if (CurrentTrainIndex > Trains.Count - 1)
            Debug.LogError("Tail Index is over.");
        
        Trains[++CurrentTrainIndex].gameObject.SetActive(true);
        Trains[CurrentTrainIndex].Init(this, type, TrainDatas[CurrentTrainIndex].Damage, TrainDatas[CurrentTrainIndex].CoolTime);
    }

    public Transform GetAttackTarget()
    {
        if (_attackIndex > CurrentTrainIndex)
            _attackIndex = 0;
        return Trains[_attackIndex++].transform;
    }
}
