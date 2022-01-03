using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuitButton : MonoBehaviour
{
    private void Awake() => GetComponent<Button>().onClick.AddListener(OnClick);
    private void OnClick() => Application.Quit();
}
