using System;
using System.Text;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ResultUI : MonoBehaviour
{
    private TMP_Text _text;

    [SerializeField] private Color32 _correctColour;
    [SerializeField] private Color32 _incorrectColour;

    private string _correctColourHex;
    private string _incorrectColourHex;

    private StringBuilder _sb = new StringBuilder();
    private int _roundNumber;

    private void Awake()
    {
        GameManager.OnResult += GameManager_OnResult;
        GameManager.OnGameStart += GameManager_OnGameStart;

        _text = GetComponent<TMP_Text>();
        Reset();

        //Set hex values for each colour
        _correctColourHex = ColorUtility.ToHtmlStringRGBA(_correctColour);
        _incorrectColourHex = ColorUtility.ToHtmlStringRGBA(_incorrectColour);
    }

    private void GameManager_OnGameStart() => Reset();

    private void Reset()
    {
        _text.text = "";
        _sb = new StringBuilder();
        _roundNumber = 0;
    }

    private void GameManager_OnResult(bool result)
    {
        _roundNumber++;

        //Append round number
        _sb.Append($"Round {_roundNumber}: ");

        //Append outcome
        if(result)
            _sb.Append($"<color=#{_correctColourHex}>Correct</color>");
        else
            _sb.Append($"<color=#{_incorrectColourHex}>Incorrect</color>");

        //Append time
        _sb.Append($" - {Math.Round(Time.realtimeSinceStartup - GameManager.LastAttemptTime, 2)} seconds.");

        _sb.AppendLine();
        _text.text = _sb.ToString();
    }
}
