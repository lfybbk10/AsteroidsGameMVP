using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NloModel
{
    [SerializeField] private float _speed = 4f;

    private Transform _target;
    private Transform _transform;
    private Rigidbody2D _rigidbody;

    public NloModel(Transform player, Rigidbody2D rigidbody)
    {
        _transform = rigidbody.GetComponent<Transform>();
        _target = player;
        _rigidbody = rigidbody;
    }

    public void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 direction = (_target.position - _transform.position).normalized;
        _rigidbody.velocity = direction * _speed;
    }
}
