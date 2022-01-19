using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModel : IUpdatable
{
    private float _currentSpeed = 0;
    private float _maxSpeed = 5f;
    private float _minSpeed = .01f;
    private float _speedIncreaseStep = 1f;
    private float _speedDecreaseStep = 1.2f;
    private bool _isAccalerating;

    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private Vector2 _forward;
    private Vector2 _currentForward;

    public ShipModel (Rigidbody2D rigidbody)
    {
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
        if(_currentSpeed < _maxSpeed)
            _currentSpeed += _speedIncreaseStep * deltaTime;
        _rigidbody.velocity = _currentForward * _currentSpeed;
    }

    public void SlowDown(float deltaTime)
    {
        if(_currentSpeed <= _minSpeed)
        {
            _currentSpeed = 0;
            return;
        }
        _currentSpeed -= _speedDecreaseStep * deltaTime;
        _rigidbody.velocity = _forward * _currentSpeed;
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
        float dX = targetPosition.x - _rigidbody.position.x;
        float dY = targetPosition.y - _rigidbody.position.y;
        float targetRotation = Mathf.Atan2(dY, dX) * (180 / Mathf.PI);
        _transform.rotation = Quaternion.Euler(0, 0, targetRotation - 90);
    }

}
