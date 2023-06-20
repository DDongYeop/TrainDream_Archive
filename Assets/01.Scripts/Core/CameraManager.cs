using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    
    private CinemachineVirtualCamera _followCam;
    private CinemachineBasicMultiChannelPerlin _camPerlin;

    private float _initPower;
    private float _initTime;
    private float _currentShakeTime;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple CameraManager is running");
        Instance = this;
        
        _followCam = GetComponent<CinemachineVirtualCamera>();
        _camPerlin = _followCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _camPerlin.m_AmplitudeGain = 0;
    }

    public void AddShake(float power, float time)
    {
        _camPerlin.m_AmplitudeGain = _initPower = power;
        _currentShakeTime = _initTime = time;
    }

    private void Update()
    {
        if (_currentShakeTime > 0)
        {
            _currentShakeTime -= Time.deltaTime;

            float ampGain = Mathf.Lerp(_initPower, 0, _currentShakeTime / _initTime);
            _camPerlin.m_AmplitudeGain = ampGain;

            if (_currentShakeTime <= 0)
            {
                _currentShakeTime = 0;
                _camPerlin.m_AmplitudeGain = 0;
            }
        }
    }
}