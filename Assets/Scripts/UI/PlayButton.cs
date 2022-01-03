using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayButton : MonoBehaviour
{
    private void Awake() => GetComponent<Button>().onClick.AddListener(OnClick);
    private void OnClick() => GameManager.OnGameStart?.Invoke();
}
