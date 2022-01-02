using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ResultUI : MonoBehaviour
{
    private TMP_Text _text;

    [SerializeField] private string _correctText;
    [SerializeField] private string _incorrectText;

    [SerializeField] private Color32 _correctColour;
    [SerializeField] private Color32 _incorrectColour;

    private void Awake()
    {
        GameManager.OnResult += GameManager_OnResult;
        _text = GetComponent<TMP_Text>();
        _text.text = "";
    }

    private void GameManager_OnResult(bool result)
    {
        if(result)
        {
            _text.text = _correctText;
            _text.color = _correctColour;
        }
        else
        {
            _text.text = _incorrectText;
            _text.color = _incorrectColour;
        }
    }
}
