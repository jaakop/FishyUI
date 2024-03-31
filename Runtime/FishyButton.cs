using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FishyUI
{
    [AddComponentMenu("UI/Fishy UI/Button")]
    public class FishyButton : Button, IThemedUIComponent
    {
        public int themeIndex = 0;
        public ButtonTheme overrideTheme;
        public bool OverrideThemeWithLocal;

        protected override void Awake()
        {
            ApplyTheme();
        }

        public void ApplyTheme()
        {
            if (OverrideThemeWithLocal) return;

            var theme = overrideTheme;
            if (theme == null)
            {
                var buttonThemes = GetComponentInParent<FishyCanvas>()?.theme?.buttonThemes;
                if (buttonThemes == null || buttonThemes.Length == 0) 
                    return;


                if (buttonThemes.Length <= themeIndex)
                {
                    theme = buttonThemes[0];
                    Debug.LogError($"Could not find theme with index {themeIndex} from the themed canvas. Using default default theme");
                }
                else
                    theme = buttonThemes[themeIndex];
            }

            var img = GetComponent<Image>();

            img.sprite = theme.Sprite;
            img.type = theme.imageType;
            img.color = theme.Color;
            img.pixelsPerUnitMultiplier = theme.imagePixelsPerUnitMultiplier;
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("GameObject/UI/Fishy UI/Button")]
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

        protected override void OnValidate()
        {
            base.OnValidate();
            ApplyTheme();
        }
    }
}