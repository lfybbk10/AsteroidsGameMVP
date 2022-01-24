using UnityEngine;

public class DefoultBulletModel
{
    private float _speed = 1000f;

    public DefoultBulletModel(Rigidbody2D rigidbody, Vector2 direction)
    {
        rigidbody.AddForce(direction * _speed);
    }
}
