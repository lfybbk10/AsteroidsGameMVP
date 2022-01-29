using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGunRollback 
{
    private readonly float _cooldown = 3f;

    private float _elapsedTime = 0;

    public bool CanShoot => _elapsedTime <= 0;

    public void Update(float deltaTime)
    {
        if (_elapsedTime <= 0)
            return;

        _elapsedTime -= deltaTime;
    }

    public void SetShoted()
    {
        _elapsedTime = _cooldown;
    }
}
