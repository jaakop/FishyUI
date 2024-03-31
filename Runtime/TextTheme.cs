using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace FishyUI
{
    [CreateAssetMenu(fileName = "Text Theme", menuName = "FishyUI/Text Theme")]
    public class TextTheme : ScriptableObject
    {
        public Color Color;
        public TMP_FontAsset Font;
        public float FontSize;
    }

}