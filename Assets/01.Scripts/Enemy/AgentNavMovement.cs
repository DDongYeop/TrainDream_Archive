using UnityEngine;
using UnityEngine.AI;

public class AgentNavMovement : MonoBehaviour
{
    [SerializeField] private float _gravity = -9.8f;
    private float _verticalVelocity;
    private Vector3 _movementVelocity;

    private NavMeshAgent _navAgent;
    public NavMeshAgent NavAgent => _navAgent;

    private CharacterController _characterController;

    private bool _isControllerMode = true;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _navAgent = GetComponent<NavMeshAgent>();
        _navAgent.speed = 12.5f;
    }
    
    private void FixedUpdate()
    {
        if (!_isControllerMode)
            return;

        if(_characterController.isGrounded == false)
            _verticalVelocity = _gravity * Time.fixedDeltaTime;
        else
            _verticalVelocity = _gravity * 0.3f * Time.fixedDeltaTime;

        Vector3 move = _movementVelocity + _verticalVelocity * Vector3.up;
        _characterController.Move(move);
    }

    public bool IsFall()
    {
        return _characterController.isGrounded;
    }

    public void AgentTargetSet(Transform trm)
    {
        _navAgent.SetDestination(trm.position);
    }

    public void AgentStop()
    {
        _navAgent.SetDestination(transform.position);
    }

    public void ControllModeSet(bool value)
    {
        _isControllerMode = value;
    }
}
