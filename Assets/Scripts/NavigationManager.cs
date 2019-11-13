using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NavigationManager : MonoBehaviour
{
    [SerializeField] Text yearTitle;
    [SerializeField] Text monthTitle;
    [SerializeField] Text title;
    [SerializeField] GameObject backButton;
    [SerializeField] RectTransform leftButtonArea;
    [SerializeField] RectTransform rightButtonArea;
    [SerializeField] MainManager mainManager;
    public string Title
    {
        get
        {
            return title.text;
        }
        set
        {
            title.text = value;
        }
    }
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
    public void SetYearMonth(string year, string month)
    {
        yearTitle.text = year;
        monthTitle.text = month;
    }
    //public void ShowBackButton(bool isShow)
    //{
    //    backButton.SetActive(isShow);
    //}
}
