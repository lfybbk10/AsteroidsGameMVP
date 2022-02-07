using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModel : IUpdatable
{
    private bool _isAccalerating;
    private ShipRotator _shipRotator;
    private ShipMover _shipMover;
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private Vector2 _forward;
    private Vector2 _currentForward;

    public ShipModel (Rigidbody2D rigidbody)
    {
        _shipRotator = new ShipRotator();
        _shipMover = new ShipMover();
        _rigidbody = rigidbody;
        _transform = rigidbody.GetComponent<Transform>();
        _currentForward = _transform.up;
    }

    public void Update(float deltaTime)
    {
        if(_isAccalerating == true)
            _currentForward = Vector2.Lerp(_currentForward, _transform.up, deltaTime);
    }
    
    public void Accalerate(float deltaTime)
    {
        _shipMover.Accalerate(deltaTime, _rigidbody, _currentForward);
    }

    public void SlowDown(float deltaTime)
    {
        _shipMover.SlowDown(deltaTime, _rigidbody, _forward);
    }

    public void StopAccalarating()
    {
        _isAccalerating = false;
        _forward = _currentForward;
    }

    public void StartAccalerating()
    {
        _isAccalerating = true;
    }


    public void Rotate(Vector2 targetPosition)
    {
        _transform.rotation = _shipRotator.Rotate(targetPosition, _rigidbody.position);
    }

}

[Serializable]
public class ShipMover
{
    [SerializeField] private float _currentSpeed = 0;
    [SerializeField] private float _maxSpeed = 6f;
    [SerializeField] private float _minSpeed = .01f;
    [SerializeField] private float _speedIncreaseStep = 1.5f;
    [SerializeField] private float _speedDecreaseStep = 1.2f;

    public void Accalerate(float deltaTime, Rigidbody2D rigidbody, Vector2 currentForward)
    {
        if (_currentSpeed < _maxSpeed)
            _currentSpeed += _speedIncreaseStep * deltaTime;
        rigidbody.velocity = currentForward * _currentSpeed;
    }

    public void SlowDown(float deltaTime, Rigidbody2D rigidbody, Vector2 forward)
    {
        if (_currentSpeed <= _minSpeed)
        {
            _currentSpeed = 0;
            return;
        }
        _currentSpeed -= _speedDecreaseStep * deltaTime;
        rigidbody.velocity = forward * _currentSpeed;
    }
}

public class ShipRotator
{
    public Quaternion Rotate(Vector2 targetPosition, Vector3 currentPosition)
    {
        float dX = targetPosition.x - currentPosition.x;
        float dY = targetPosition.y - currentPosition.y;
        float targetRotation = Mathf.Atan2(dY, dX) * (180 / Mathf.PI);
        return Quaternion.Euler(0, 0, targetRotation - 90);
    }
}
