using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    public void ChangeScore(int score)
    {
        _scoreText.text = score.ToString();
    }
}
