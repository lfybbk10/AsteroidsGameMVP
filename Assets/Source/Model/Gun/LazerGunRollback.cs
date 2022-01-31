using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LazerGunRollback 
{
    private readonly float _cooldown = 3f;

    private float _elapsedTime = 0;

    public event UnityAction OnStopRollingBack;

    public bool CanShoot => _elapsedTime <= 0;
    public float ElapsedTime => _elapsedTime;

    public void Update(float deltaTime)
    {
        if (_elapsedTime <= 0)
            return;

        DecreaseTime(deltaTime);
    }

    private void DecreaseTime(float deltaTime)
    {
        _elapsedTime -= deltaTime;

        if (_elapsedTime <= 0)
            OnStopRollingBack?.Invoke();
    }

    public void SetShoted()
    {
        _elapsedTime = _cooldown;
    }
}
