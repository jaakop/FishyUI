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
        private static void CreateNewButtonGameObject(UnityEditor.MenuCommand menuCommand)
        {
            var go = new GameObject();
            go.AddComponent<RectTransform>();
            go.AddComponent<CanvasRenderer>();
            go.AddComponent<Image>();
            go.transform.SetParent((menuCommand.context as GameObject).transform);
            go.name = "Button";
            (go.transform as RectTransform).anchoredPosition = Vector3.zero;

            var txtGo = new GameObject();
            var txtTransform = txtGo.AddComponent<RectTransform>();

            txtGo.AddComponent<CanvasRenderer>();
            txtGo.transform.SetParent(go.transform);
            txtGo.name = "Text";

            var txtC = txtGo.AddComponent<TextMeshProUGUI>();
            txtC.text = "Button";
            txtC.fontSize = 24;
            txtC.alignment = TextAlignmentOptions.Center;
            txtC.color = new Color(50 / 255f, 50 / 255f, 50 / 255f);

            txtTransform.offsetMax = new Vector2(0, 0);
            txtTransform.offsetMin = new Vector2(0, 0);
            txtTransform.anchorMax = new Vector2(1, 1);
            txtTransform.anchorMin = new Vector2(0, 0);

            go.AddComponent<FishyButton>();

        }
#endif

    }
}