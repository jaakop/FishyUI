using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.UI;

namespace FishyUI
{
    public class ThemedCanvas : MonoBehaviour
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

    }
}