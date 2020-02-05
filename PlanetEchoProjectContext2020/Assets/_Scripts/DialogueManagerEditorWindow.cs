using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DialogueManagerEditorWindow : EditorWindow
{
    private SerializedObject serializedObject;

    [MenuItem("Window/My Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(DialogueManagerEditorWindow));
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Save Json"))
        {

        }
    }
}
