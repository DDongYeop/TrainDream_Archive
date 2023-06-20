using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    
    private Rigidbody _rigidbody;
    private Vector3 _inputVelocity;
    private Vector3 _movementVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetMovePosition(Vector3 pos)
    {
        _inputVelocity = pos;
        _movementVelocity = pos;
    }

    private void CalculatePlayerMovement()
    {
        _movementVelocity = _inputVelocity * (_moveSpeed * Time.fixedDeltaTime);
        _movementVelocity = Quaternion.Euler(0, -45, 0) * _movementVelocity;

        if (_movementVelocity.sqrMagnitude > 0)
            transform.rotation = Quaternion.LookRotation(_movementVelocity);
    }

    private void FixedUpdate()
    {
        CalculatePlayerMovement();
        _rigidbody.velocity = _movementVelocity * _moveSpeed;
    }
}
