using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CustomPropertyDrawer(typeof(ColourOption))]
public class ColourOptionDrawer : PropertyDrawer
{
    readonly float _nameWidth = 100;
    readonly float _colourWidth = 150;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label.text = "";

        EditorGUI.BeginProperty(position, label, property);

        //Setup position and indent
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        //Get properties
        SerializedProperty nameProperty = property.FindPropertyRelative("name");
        SerializedProperty colourProperty = property.FindPropertyRelative("colour");

        //Create rects
        Rect nameRect = new Rect(
            position.x,
            position.y,
            _nameWidth,
            position.height);

        Rect colourRect = new Rect(position.x + position.width - _colourWidth,
            position.y,
            _colourWidth,
            position.height);

        GUIContent sampleGUIContent = new GUIContent();

        //Name
        sampleGUIContent.text = "Name";
        EditorGUIUtility.labelWidth = 40;
        EditorGUI.PropertyField(nameRect, nameProperty, sampleGUIContent);

        //Colour
        sampleGUIContent.text = "Colour";
        EditorGUIUtility.labelWidth = 45;
        EditorGUI.PropertyField(colourRect, colourProperty, sampleGUIContent);

        //Reset indent level and end
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}
