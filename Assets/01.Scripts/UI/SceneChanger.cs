using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int _sceneNum;
    [SerializeField] private ButtonDownCheck _leftButton;
    [SerializeField] private ButtonDownCheck _rightButton;
    [SerializeField] private GameObject _developingTxt;
    [SerializeField] private Slider _fllAmount;
    private float _inputTime = 0;
    public StartSceneSelect StartSceneSelecter = StartSceneSelect.TITLE;
    
    private void Update()
    {
        if (_leftButton.isDown && _rightButton.isDown)
        {   
            _inputTime += Time.unscaledDeltaTime;
            if (_inputTime >= 2)
            {
                _inputTime = 0;
                SceneChange();
            }
        }
        else 
            _inputTime = 0;

        _fllAmount.value = Mathf.Clamp(_inputTime, 0, 2) / 2;
    }

    private void SceneChange()
    {
        switch (StartSceneSelecter)
        {
            case StartSceneSelect.TITLE:
                SceneManager.LoadScene(_sceneNum);
                break;
            case StartSceneSelect.STORY:
                //스토리 TimeLine
                StopAllCoroutines();
                StartCoroutine(Developing());
                break;
            case StartSceneSelect.EXIT:
                Application.Quit();
                break;
            case StartSceneSelect.HELP:
                //help bar 띄우기 
                StopAllCoroutines();
                StartCoroutine(Developing());
                break;
        }
    }

    private IEnumerator Developing()
    {
        _developingTxt.SetActive(true);
        yield return new WaitForSeconds(1f);
        _developingTxt.SetActive(false);
    }

    public bool ButtonInput()
    {
        return _leftButton.isDown || _rightButton.isDown;
    }
}

public enum StartSceneSelect
{
    TITLE = 0,
    STORY = 1,
    EXIT = 2,
    HELP = 3
}
