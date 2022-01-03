using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MenuButton : MonoBehaviour
{
    private void Awake() => GetComponent<Button>().onClick.AddListener(OnClick);
    private void OnClick() => CanvasManager.OnShowMainMenu(true);
}
