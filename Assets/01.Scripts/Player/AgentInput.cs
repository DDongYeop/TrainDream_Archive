using System;
using UnityEngine;
using UnityEngine.Serialization;

public class AgentInput : MonoBehaviour
{
    public static AgentInput Instance;
    
    private FixedJoystick _joyStick;
    public Vector3 Pos;
    public Action<Vector3> PlayerMoveEvent;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple PlayerInput is running");
        Instance = this;

        _joyStick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
    }

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float x = _joyStick.Horizontal;
        float z = _joyStick.Vertical;
        Pos = new Vector3(x, 0, z);
        PlayerMoveEvent?.Invoke(Pos);
    }
}
