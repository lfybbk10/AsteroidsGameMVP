using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidModel
{
    private readonly float _speed = 5;

    private Vector2 _direction;
    private Rigidbody2D _rigidbody;

    public AsteroidModel(Vector2 direction, Rigidbody2D rigidbody)
    {
        _direction = direction;
        _rigidbody = rigidbody;
        _rigidbody.AddForce(_direction * _speed * 100, ForceMode2D.Impulse);
    }

}
