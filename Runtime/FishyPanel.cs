using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FishyUI
{
    public class FishyPanel : MonoBehaviour, IThemedUIComponent
    {
        public PanelTheme theme;
        public bool OverrideThemeWithLocal;

        protected void Awake()
        {
            ApplyTheme();
        }

        public void ApplyTheme()
        {
            if (OverrideThemeWithLocal) return;

            PanelTheme theme = this.theme;
            if (theme == null)
            {
                var panelThemes= GetComponentInParent<FishyCanvas>()?.theme.panelThemes;
                if(panelThemes == null ||panelThemes.Length == 0 )
                    return;

                theme = panelThemes[0];
            }

            var img = GetComponent<Image>();

            img.sprite = theme.BackgroundImage;
            img.type = theme.imageType;
            img.color = theme.Color;
            img.pixelsPerUnitMultiplier = theme.imagePixelsPerUnitMultiplier;
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("GameObject/UI/Fishy UI/Panel")]
        private static void CreateNewButtonGameObject(UnityEditor.MenuCommand menuCommand)
        {
            var go = new GameObject();
            var goTransform = go.AddComponent<RectTransform>();
            go.AddComponent<CanvasRenderer>();
            go.AddComponent<Image>();
            goTransform.SetParent((menuCommand.context as GameObject).transform);
            go.name = "Panel";
            goTransform.anchoredPosition = Vector3.zero;

            goTransform.offsetMax = new Vector2(0, 0);
            goTransform.offsetMin = new Vector2(0, 0);
            goTransform.anchorMax = new Vector2(1, 1);
            goTransform.anchorMin = new Vector2(0, 0);

            go.AddComponent<FishyPanel>();

        }
#endif

        protected void OnValidate()
        {
            ApplyTheme();
        }
    }

}