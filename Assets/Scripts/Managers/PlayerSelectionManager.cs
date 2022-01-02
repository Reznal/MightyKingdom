using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionManager : MonoBehaviour
{
    [SerializeField] private List<SelectionButton> _selectionButtons;

    private void Awake() => GameManager.OnSetPlayerOptions += GameManager_OnSetPlayerOptions;
    private void OnDestroy() => GameManager.OnSetPlayerOptions -= GameManager_OnSetPlayerOptions;

    /// <summary>
    /// Setup each button
    /// </summary>
    /// <param name="options"></param>
    private void GameManager_OnSetPlayerOptions(List<ColourOption> options)
    {
        for (int i = 0; i < _selectionButtons.Count; i++)
        {
            int index = Random.Range(0, options.Count);
            _selectionButtons[i].SetColour(options[index]);
            options.RemoveAt(index);
        }
    }
}
