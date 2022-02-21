using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScorePresenter : Presenter
{
    private PlayerScoreModel _scoreModel;
    private ScoreView _scoreView;

    public void Init(ScoreView scoreView)
    {
        _scoreModel = new PlayerScoreModel();
        _scoreView = scoreView;
        
        _scoreModel.ScoreChanged += OnScoreChanged;
    }

    public void OnEnemyDestroy(int score)
    {
        _scoreModel.AddScore(score);
    }

    private void OnDisable()
    {
        _scoreModel.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int newScore)
    {
        _scoreView.ChangeScore(newScore);
    }
}
