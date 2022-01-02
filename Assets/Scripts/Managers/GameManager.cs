using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action<ColourOption> OnSetWordDisplay;
    public static Action<List<ColourOption>> OnSetPlayerOptions;
    public static Action<string> OnAnswerAttempted;
    public static Action<bool> OnResult;

    public static readonly int AdditionalOptions = 3;

    private ColourOption _answer;
    private List<ColourOption> _playerOptions = new List<ColourOption>();

    private void Awake() => OnAnswerAttempted += AnswerAttempted;
    private void OnDestroy() => OnAnswerAttempted -= AnswerAttempted;

    private void Start() => GetRoundData();

    private void AnswerAttempted(string value)
    {
        bool won = value == _answer.name;

        OnResult?.Invoke(won);
        GetRoundData();
    }

    /// <summary>
    /// Get data for new round
    /// </summary>
    private void GetRoundData()
    {
        _playerOptions.Clear();

        List<ColourOption> options = new List<ColourOption>(ColourManager.instance.Colours);

        //Get answer
        _answer = GetOption(options);

        //Get additional options for player selection
        for (int i = 0; i < AdditionalOptions; i++)
        {
            _playerOptions.Add(GetOption(options));
        }

        //Set word display - use the first additional option for the word
        OnSetWordDisplay?.Invoke(new ColourOption(_playerOptions[0].name, _answer.colour));

        //Add the answer to the player options
        _playerOptions.Add(_answer);

        OnSetPlayerOptions?.Invoke(_playerOptions);
    }

    /// <summary>
    /// Pick a random option and remove it from the given list
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    private ColourOption GetOption(List<ColourOption> options)
    {
        int index = UnityEngine.Random.Range(0, options.Count);
        ColourOption returnValue = options[index];
        options.RemoveAt(index);
        return returnValue;
    }
}
