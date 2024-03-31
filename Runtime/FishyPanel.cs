using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FishyUI
{
    public class FishyPanel : MonoBehaviour, IThemedUIComponent
    {
        public int themeIndex = 0;
        public PanelTheme overrideTheme;
        public bool OverrideThemeWithLocal;

        protected void Awake()
        {
            ApplyTheme();
        }

        public void ApplyTheme()
        {
            if (OverrideThemeWithLocal) return;

            var theme = overrideTheme;
            if (theme == null)
            {
                var panelThemes= GetComponentInParent<FishyCanvas>()?.theme.panelThemes;
                if(panelThemes == null ||panelThemes.Length == 0 )
                    return;

                if (panelThemes.Length <= themeIndex)
                {
                    theme = panelThemes[0];
                    Debug.LogError($"Could not find theme with index {themeIndex} from the themed canvas. Using default default theme");
                }
                else
                    theme = panelThemes[themeIndex];
            }

            var img = GetComponent<Image>();

            img.sprite = theme.BackgroundImage;
            img.type = theme.imageType;
            img.color = theme.Color;
            img.pixelsPerUnitMultiplier = theme.imagePixelsPerUnitMultiplier;
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("GameObject/UI/Fishy UI/Text")]
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

            go.AddComponent<FishyText>().text = "Fishy text";

        }
#endif

        protected void OnValidate()
        {
            ApplyTheme();
        }
    }

}