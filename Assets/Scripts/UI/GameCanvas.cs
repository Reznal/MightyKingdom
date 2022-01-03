using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private GameObject _endObject;

    public void Awake()
    {
        GameManager.OnGameStart += GameManager_OnGameStart;
        GameManager.OnGameEnded += GameManager_OnGameEnded;

        ChangeDisplay(true);
    }

    private void OnDestroy()
    {
        GameManager.OnGameStart -= GameManager_OnGameStart;
        GameManager.OnGameEnded -= GameManager_OnGameEnded;
    }

    private void GameManager_OnGameEnded() => ChangeDisplay(false);
    private void GameManager_OnGameStart() => ChangeDisplay(true);

    private void ChangeDisplay(bool gameInProgress)
    {
        _gameObject.SetActive(gameInProgress);
        _endObject.SetActive(!gameInProgress);
    }
}
