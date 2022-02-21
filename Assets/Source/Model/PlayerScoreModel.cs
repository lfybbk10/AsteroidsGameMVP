using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScoreModel
{
    private int _currentScore = 0;

    public event UnityAction<int> ScoreChanged;

    public void AddScore(int score)
    {
        _currentScore += score;
        ScoreChanged?.Invoke(_currentScore);
    }
}
