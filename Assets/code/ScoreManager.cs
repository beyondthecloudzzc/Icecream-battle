using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public Text _scoreText;
    void Start()
    {
        score = 0;
        SetScore(0);
    }
    void SetScore(int _score)
    {
        score += _score;
        _scoreText.text = score.ToString();
    }
}
