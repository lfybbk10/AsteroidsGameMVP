using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModel : IUpdatable
{
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private Vector2 _forward;

    private float _currentSpeed = 0;
    private float _maxSpeed = 5f;
    private float _minSpeed = .01f;
    private float _speedIncreaseStep = 1f;
    private float _speedDecreaseStep = 1.2f;

    public ShipModel (Rigidbody2D rigidbody)
    {
        _rigidbody = rigidbody;
        _transform = rigidbody.GetComponent<Transform>();
    }

    public void Update()
    {

    }
    
    public void Accalerate(float deltaTime)
    {
        if(_currentSpeed < _maxSpeed)
            _currentSpeed += _speedIncreaseStep * deltaTime;
        
        _rigidbody.velocity = _transform.up * _currentSpeed;
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

    public void SetDirection()
    {
        _forward = _transform.up;
    }


    public void Rotate(Vector2 targetPosition)
    {
        float dX = targetPosition.x - _rigidbody.position.x;
        float dY = targetPosition.y - _rigidbody.position.y;
        float targetRotation = Mathf.Atan2(dY, dX) * (180 / Mathf.PI);
        _transform.rotation = Quaternion.Euler(0, 0, targetRotation - 90);
    }

}
