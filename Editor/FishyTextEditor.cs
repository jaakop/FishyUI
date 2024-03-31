using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;
using TextEditor = UnityEditor.UI.TextEditor;


namespace FishyUI
{
    [CustomEditor(typeof(FishyText), true)]
    [CanEditMultipleObjects]
    public class FishyTextEditor : TMP_EditorPanelUI
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
            (target as FishyText).ApplyTheme();

            base.OnInspectorGUI();
        }
    }
}