using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class WordUI : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        GameManager.OnSetWordDisplay += GameManager_OnSetWordDisplay;
        _text = GetComponent<TMP_Text>();
    }

    private void GameManager_OnSetWordDisplay(ColourOption option)
    {
        _text.text = option.name;
        _text.color = option.colour;
    }
}
