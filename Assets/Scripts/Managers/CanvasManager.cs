using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static Action<bool> OnShowMainMenu;

    [SerializeField] private Canvas _startCanvas;
    [SerializeField] private Canvas _gameCanvas;

    private void Awake() => OnShowMainMenu += SetCanvasDisplay;
    private void OnDestroy() => OnShowMainMenu -= SetCanvasDisplay;

    /// <summary>
    /// Set specific canvases display
    /// </summary>
    private void SetCanvasDisplay(bool value)
    {
        _startCanvas.gameObject.SetActive(value);
        _gameCanvas.gameObject.SetActive(!value);
    }
}