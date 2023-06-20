using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ExperienceBar : MonoBehaviour
{
    private UIDocument _document;
    private VisualElement _root;

    private Label _levelLabel;
    private VisualElement _fillArea;

    [Header("Level")] 
    [SerializeField] private int _initLevel;
    [SerializeField] private int _initExperience;
    [SerializeField] private int _initExperienceMax;
    
    private int _level = 1;
    private float _experience;
    private float _experienceMax;
    
    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _level = _initLevel;
        _experience = _initExperience;
        _experienceMax = _initExperienceMax;
    }

    private void Update()
    {
        AddExperience();
    }

    private void OnEnable()
    {
        _root = _document.rootVisualElement;
        _levelLabel = _root.Q<Label>("Level");
        _fillArea = _root.Q<VisualElement>("FillArea");
    }
    
    // 대충 % 뭐 어쩌구 저쩌구 해서 
    // FillArea 채워주고, 레벨 적용 시키기
    // 수학때 배운 등비수열 사용해보면 좋을듯 
    public void AddExperience(float experience = 0)
    {
        if (_level >= 4)
        {
            _levelLabel.text = "Lv.MAX";
            _fillArea.style.flexBasis = Length.Percent(100f);
            return;
        }
        
        _experience += experience;
        if (_experience >= _experienceMax)
        {
            ++_level;
            _experience -= _experienceMax;
            _experienceMax *= 2;
            UIManager.Instance.UIShow(UIType.TrainSelect, true, 1);
            AddExperience();
        }

        _levelLabel.text = "Lv." + _level;
        _fillArea.style.flexBasis = Length.Percent(_experience / _experienceMax * 100f);
    }

    public void SupportExperience(int index)
    {
        _experience += Time.deltaTime * index * 0.1f;
        AddExperience();
    }
}
