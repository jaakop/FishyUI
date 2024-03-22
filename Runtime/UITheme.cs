using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UI Theme", menuName = "FishyUI/UI Theme")]
public class UITheme : ScriptableObject
{
    [SerializeField]
    public ButtonTheme[] buttonThemes;
}