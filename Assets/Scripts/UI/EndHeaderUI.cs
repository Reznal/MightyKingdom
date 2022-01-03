using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class EndHeaderUI : MonoBehaviour
{
    private TMP_Text _text;
    private void Awake()
    {
        GameManager.OnGameEnded += GameManager_OnGameEnded;
        _text = GetComponent<TMP_Text>();
    }

    private void OnDestroy() => GameManager.OnGameEnded -= GameManager_OnGameEnded;

    private void GameManager_OnGameEnded()
    {
        double time = Math.Round(Time.realtimeSinceStartup - GameManager.GameStartTime, 2);
        _text.text = $"You answered {GameManager.CorrectAnswers}/{ColourManager.instance.Colours.Count} correctly in {time} seconds.";
    }
}
