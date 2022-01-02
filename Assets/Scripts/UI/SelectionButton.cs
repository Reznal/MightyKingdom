using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class SelectionButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Image _image;
    private string _value;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        _image = GetComponent<Image>();
    }

    private void OnClick() => GameManager.OnAnswerAttempted?.Invoke(_value);

    public void SetColour(ColourOption option)
    {
        _text.text = option.name;
        _image.color = option.colour;

        _value = option.name;
    }
}
