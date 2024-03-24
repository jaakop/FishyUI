using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FishyUI
{
    [CreateAssetMenu(fileName = "Panel Theme", menuName = "FishyUI/Panel Theme")]
    public class PanelTheme : ScriptableObject
    {
        public Sprite BackgroundImage;

        public Color Color;

        public Image.Type imageType;

        public float imagePixelsPerUnitMultiplier;
    }
}
