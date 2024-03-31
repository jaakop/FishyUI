using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FishyUI
{
    public class FishyText : TextMeshProUGUI, IThemedUIComponent
    {
        public TextTheme theme;
        public bool OverrideThemeWithLocal;

        protected override void Awake()
        {
            base.Awake();
            ApplyTheme();
        }

        public void ApplyTheme()
        {
            if (OverrideThemeWithLocal) return;

            TextTheme theme = this.theme;
            if (theme == null)
            {
                var textThemes = GetComponentInParent<FishyCanvas>()?.theme.textThemes;
                if (textThemes == null || textThemes.Length == 0)
                    return;

                theme = textThemes[0];

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