using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Gameover : MonoBehaviour
{
    private UIDocument _uiDocument;
    private VisualElement _root;

    private VisualElement _backGround;
    private Label _livingTimeLabel;
    private Button _titleButton;
    private Button _reStartButton;

    private float _startTime;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void Start()
    {
        _startTime = Time.time;
        UIManager.Instance.UIShow(UIType.GameOver, false, 1);
    }

    private void OnEnable()
    {
        _root = _uiDocument.rootVisualElement;
        _backGround = _root.Q<VisualElement>("BackGround");
        _livingTimeLabel = _root.Q<Label>("LivingTimeTxt");
        _titleButton = _root.Q<Button>("TitleButton");
        _reStartButton = _root.Q<Button>("ReStartButton");

        _livingTimeLabel.text = $"{Time.time - _startTime:N1}"; 
        _titleButton.RegisterCallback<ClickEvent>(evt => SceneManager.LoadScene(0));
        _reStartButton.RegisterCallback<ClickEvent>(evt => SceneManager.LoadScene(1));
        
        _backGround.AddToClassList("Show");
    }
}
