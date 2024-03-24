using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FishyUI
{
    [CreateAssetMenu(fileName = "Button Theme", menuName = "FishyUI/Button Theme")]
    public class ButtonTheme : ScriptableObject
    {
        public Sprite Sprite;

        public Color Color;

        public Image.Type imageType;

        public float imagePixelsPerUnitMultiplier;

    }
}