using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPresenter : Presenter
{
    [SerializeField] private int _reward;
    private PlayerScorePresenter _scorePresenter;

    public void Init(PlayerScorePresenter playerScore)
    {
        _scorePresenter = playerScore;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IBullet bullet))
            Die();
    }

    protected virtual void Die()
    {
        _scorePresenter.OnEnemyDestroy(_reward);
        Destroy(gameObject);
    }
}
