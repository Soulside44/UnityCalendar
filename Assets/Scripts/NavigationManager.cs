using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationManager : MonoBehaviour
{
    [SerializeField] Text yearTitle;
    [SerializeField] Text monthTitle;
    [SerializeField] RectTransform leftButtonArea;
    [SerializeField] RectTransform rightButtonArea;
    [SerializeField] MainManager mainManager;

    public string Year
    {
        get
        {
            return yearTitle.text;
        }
        set
        {
            yearTitle.text = value;
        }
    }
    public string Month
    {
        get
        {
            return monthTitle.text;
        }
        set
        {
            monthTitle.text = value;
        }
    }
    public RectTransform LeftButtonArea
    {
        get
        {
            return leftButtonArea;
        }
    }
    public RectTransform RightButtonArea
    {
        get
        {
            return rightButtonArea;
        }
    }
}
