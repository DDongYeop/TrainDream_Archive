using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class TrainSelect : MonoBehaviour
{
    [SerializeField] private float _delTime = 0.3f;
    private UIDocument _document;
    private VisualElement _root;
    private List<Button> _cards = new List<Button>();
    private bool _isInput = false;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        for (int i = 0; i < 3; ++i)
            _cards.Add(null);
        
        _isInput = false;
        _root = _document.rootVisualElement;
        StopAllCoroutines();
        StartCoroutine(CardShowCo());
    }

    private IEnumerator CardShowCo()
    {
        for (int i = 1; i < 4; ++i)
        {
            yield return new WaitForSecondsRealtime(_delTime);
            CardShow(i);
        }
        Time.timeScale = 0;
    }
    
    private IEnumerator CardUnShowCo()
    {
        for (int i = 0; i < 3; ++i)
        {
            _cards[i].RemoveFromClassList("on");
            yield return new WaitForSecondsRealtime(_delTime);
        }
        
        UIManager.Instance.UIShow(UIType.TrainSelect, false, 1);
    }

    private void CardShow(int index) //차후 업그래이드 개발. 
    {
        --index;
        _cards[index] = _root.Q<Button>("Card0" + (index+1));
        /*if (Random.Range(0, 3) == 0 || AgentTrainController.Instance.CurrentTrainIndex >= AgentTrainController.Instance.Trains.Count - 1)
        {
            // TrainController에서 지금 있는 애들 가져와서 
            // 대충 업그래이드 만들기
            Label name = _cards[index].Q<Label>("Name");
            name.text = "Upgrade";
        }*/
        //else
        {
            int num = Random.Range(1, 6);
            Label name = _cards[index].Q<Label>("Name");
            Label info = _cards[index].Q<Label>("Info");
            VisualElement image = _cards[index].Q<VisualElement>("Image");
            name.text = AgentTrainController.Instance.TrainDatas[num].Name;
            info.text = AgentTrainController.Instance.TrainDatas[num].Info;
            image.style.backgroundImage = new StyleBackground(Background.FromRenderTexture(AgentTrainController.Instance.TrainDatas[num].Texture));
            
            _cards[index].RegisterCallback<ClickEvent>(evt =>
            {
                if (_isInput)
                    return;
                _isInput = true;
                AgentTrainController.Instance.AddTrain((TrainType)num);
                StartCoroutine(CardUnShowCo());
            });
        }
        
        _cards[index].AddToClassList("on");
    }
}
