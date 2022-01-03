using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action OnGameStart;
    public static Action OnGameEnded;
    public static Action<ColourOption> OnSetWordDisplay;
    public static Action<List<ColourOption>> OnSetPlayerOptions;
    public static Action<string> OnAnswerAttempted;
    public static Action<bool> OnResult;

    //Time
    public static float GameStartTime { get; private set; }
    public static float LastAttemptTime { get; private set; }
    public static readonly int AdditionalOptions = 3;

    //Current score
    public static int CorrectAnswers { get; private set; }

    //Options
    private ColourOption _answer;
    private List<ColourOption> _answerOptions = new List<ColourOption>();
    private List<ColourOption> _playerOptions = new List<ColourOption>();

    private void Awake()
    {
        OnGameStart += GameStart;
        OnAnswerAttempted += AnswerAttempted;
    }

    private void OnDestroy()
    {
        OnGameStart -= GameStart;
        OnAnswerAttempted -= AnswerAttempted;
    }

    private void Start() => CanvasManager.OnShowMainMenu?.Invoke(true);

    /// <summary>
    /// Start a new game
    /// </summary>
    private void GameStart()
    {
        CorrectAnswers = 0;

        CanvasManager.OnShowMainMenu?.Invoke(false);

        GameStartTime = Time.realtimeSinceStartup;
        LastAttemptTime = GameStartTime;

        _answerOptions = new List<ColourOption>(ColourManager.instance.Colours);
        GetRoundData();
    }

    /// <summary>
    /// Player attempted an answer
    /// Display result and new round
    /// </summary>
    /// <param name="value"></param>
    private void AnswerAttempted(string value)
    {
        bool won = value == _answer.name;

        if (won)
            CorrectAnswers++;

        OnResult?.Invoke(won);

        if (_answerOptions.Count <= 0)
        {
            FinishRound();
            return;
        }

        GetRoundData();

        LastAttemptTime = Time.realtimeSinceStartup;
    }

    /// <summary>
    /// Get data for new round
    /// </summary>
    private void GetRoundData()
    {
        _playerOptions.Clear();

        //Get answer
        _answer = GetOption(_answerOptions);

        //Get a list of additional options
        List<ColourOption> options = new List<ColourOption>(ColourManager.instance.Colours).Where(x => x.name != _answer.name).ToList();

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

    private void FinishRound()
    {
        Debug.Log("Finish");
        OnGameEnded?.Invoke();
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
