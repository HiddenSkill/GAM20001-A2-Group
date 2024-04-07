using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region Fields

    private int _score;
    private TextMeshProUGUI _text;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _text = GetComponent<TextMeshProUGUI>();

        UpdateScoreText();
    }

    public void AddScore(int score)
    {
        _score += score;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _text.text = "Score: " + _score.ToString();
    }

    #endregion
}
