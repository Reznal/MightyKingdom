using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour
{
    public static ColourManager instance;

    [Header("Colour options")]
    [SerializeField]private List<ColourOption> _colours;
    public List<ColourOption> Colours => _colours;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    /// <summary>
    /// Gets a random colour
    /// </summary>
    /// <returns></returns>
    public ColourOption GetColour() => _colours[Random.Range(0, _colours.Count)];
}

[System.Serializable]
public struct ColourOption
{
    public string name;
    public Color32 colour;

    public ColourOption(string name, Color32 colour)
    {
        this.name = name;
        this.colour = colour;
    }
}