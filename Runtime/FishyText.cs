using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FishyUI
{
    public class FishyText : TextMeshProUGUI, IThemedUIComponent
    {
        public int themeIndex = 0;
        public TextTheme overrideTheme;
        public bool OverrideThemeWithLocal;

        protected override void Awake()
        {
            base.Awake();
            ApplyTheme();
        }

        public void ApplyTheme()
        {
            if (OverrideThemeWithLocal) return;

            TextTheme theme = this.overrideTheme;
            if (theme == null)
            {
                var textThemes = GetComponentInParent<FishyCanvas>()?.theme.textThemes;
                if (textThemes == null || textThemes.Length == 0)
                    return;

                if (textThemes.Length <= themeIndex)
                {
                    theme = textThemes[0];
                    Debug.LogError($"Could not find theme with index {themeIndex} from the themed canvas. Using default default theme");
                }
                else
                    theme = textThemes[themeIndex];

                this.font = theme.Font;
                this.fontSize = theme.FontSize;
                this.color = theme.Color;
            }
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("GameObject/UI/Fishy UI/Panel")]
        private static void CreateNewButtonGameObject(UnityEditor.MenuCommand menuCommand)
        {
            var go = new GameObject();
            var goTransform = go.AddComponent<RectTransform>();
            go.AddComponent<CanvasRenderer>();
            goTransform.SetParent((menuCommand.context as GameObject).transform);
            go.name = "Text";
            goTransform.anchoredPosition = Vector3.zero;

            goTransform.offsetMax = new Vector2(0, 0);
            goTransform.offsetMin = new Vector2(0, 0);
            goTransform.anchorMax = new Vector2(1, 1);
            goTransform.anchorMin = new Vector2(0, 0);

            go.AddComponent<FishyText>();

        }
#endif

        protected override void OnValidate()
        {
            base.OnValidate();
            ApplyTheme();
        }
    }

}