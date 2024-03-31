using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;


namespace FishyUI
{
    [CustomEditor(typeof(FishyButton), true)]
    [CanEditMultipleObjects]
    public class FishyButtonEditor : ButtonEditor
    {
        SerializedProperty themeIndex;
        SerializedProperty overrideTheme;
        SerializedProperty overrideBool;

        protected override void OnEnable()
        {
            base.OnEnable();
            themeIndex = serializedObject.FindProperty("themeIndex");
            overrideTheme = serializedObject.FindProperty("overrideTheme");
            overrideBool = serializedObject.FindProperty("OverrideThemeWithLocal");
        }


        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(themeIndex);
            EditorGUILayout.PropertyField(overrideTheme);
            EditorGUILayout.PropertyField(overrideBool);

            EditorGUILayout.Space();

            serializedObject.ApplyModifiedProperties();
            (target as FishyButton).ApplyTheme();

            base.OnInspectorGUI();
        }
    }
}