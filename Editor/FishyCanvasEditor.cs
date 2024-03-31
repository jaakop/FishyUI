using UnityEngine;
using UnityEditor;

namespace FishyUI
{
    [CustomEditor(typeof(FishyCanvas))]
    public class FishyCanvasEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Configure"))
            {
                serializedObject.ApplyModifiedProperties();
                (target as FishyCanvas).Init();
            }
        }
    }
}