using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FishyUI
{
    [AddComponentMenu("UI/Fishy UI/Button")]
    public class FishyButton : Button, IThemedUIComponent
    {
        public ButtonTheme theme;
        public bool OverrideThemeWithLocal;

        protected override void Awake()
        {
            ApplyTheme();
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ApplyTheme()
        {
            if (OverrideThemeWithLocal) return;

            ButtonTheme buttonTheme = theme;
            if (buttonTheme == null) { buttonTheme = GetComponentInParent<ThemedCanvas>()?.theme?.buttonThemes[0]; }

            var img = GetComponent<Image>();

            img.sprite = buttonTheme.Sprite;
            img.type = buttonTheme.imageType;
            img.color = buttonTheme.Color;
            img.pixelsPerUnitMultiplier = buttonTheme.imagePixelsPerUnitMultiplier;
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("GameObject/UI/Fishy UI/Button")]
        static private void CreateNewButtonGameObject(UnityEditor.MenuCommand menuCommand)
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