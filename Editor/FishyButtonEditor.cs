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
        SerializedProperty theme;
        SerializedProperty overrideBool;

        protected override void OnEnable()
        {
            base.OnEnable();
            theme = serializedObject.FindProperty("theme");
            overrideBool = serializedObject.FindProperty("OverrideThemeWithLocal");
        }


        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(theme);
            EditorGUILayout.PropertyField(overrideBool);

            EditorGUILayout.Space();

            serializedObject.ApplyModifiedProperties();
            (target as FishyButton).ApplyTheme();

            base.OnInspectorGUI();
        }
    }
}