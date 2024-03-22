using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ThemedCanvas))]
public class ThemedCanvasEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Configure"))
        {
            serializedObject.ApplyModifiedProperties();
            (target as ThemedCanvas).Init();
        }
    }
}
