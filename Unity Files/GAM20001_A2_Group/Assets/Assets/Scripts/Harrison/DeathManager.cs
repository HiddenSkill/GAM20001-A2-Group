using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    #region Fields

    private int _numDeaths;
    private TextMeshProUGUI _text;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        _numDeaths = 0;
        _text = GetComponent<TextMeshProUGUI>();

        UpdateScoreText();
    }

    public void AddDeath()
    {
        _numDeaths++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _text.text = _numDeaths.ToString();
    }

#endregion
}
