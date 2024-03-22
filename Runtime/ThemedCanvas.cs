using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.UI;

public class ThemedCanvas : MonoBehaviour
{
    public UITheme theme;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        Setup();
        Configure();
        Canvas.ForceUpdateCanvases();

        foreach (var component in GetComponentsInChildren<IThemedUIComponent>())
        {
            component.ApplyTheme();
        }
    }

    private void Setup()
    {

    }

    private void Configure()
    {
    }

    private void OnValidate()
    {
        Init();
    }

}
