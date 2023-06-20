using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private List<GameObject> _uis = new List<GameObject>();

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple UIManager is running");
        Instance = this;
        
    }
    
    public void UIShow(UIType type, bool value = true, float time = 1f)
    {
        _uis[(int)type].SetActive(value);
        Time.timeScale = time;
    }
}
