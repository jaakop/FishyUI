using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.UI;

namespace FishyUI
{
    public class FishyCanvas : MonoBehaviour
    {
        public UITheme theme;
        public bool OverrideWithLocals;

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            Setup();
            Configure();
            Canvas.ForceUpdateCanvases();

            foreach (var component in GetComponentsInChildren<IThemedUIComponent>())
            {
                component.ApplyTheme();
            }
        }

        private void Setup()
        {

        }

        private void Configure()
        {
            if(OverrideWithLocals) { return; }

            GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        }

        private void OnValidate()
        {
            Init();
        }



#if UNITY_EDITOR
        [UnityEditor.MenuItem("GameObject/UI/Fishy UI/Canvas")]
        private static void CreateNewCanvasGameObject(UnityEditor.MenuCommand menuCommand)
        {
            var go = new GameObject();
            go.AddComponent<RectTransform>();
            go.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            go.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            go.AddComponent<GraphicRaycaster>();

            go.name = "Canvas";

            go.AddComponent<FishyCanvas>();

        }
#endif

    }
}