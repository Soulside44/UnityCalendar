﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CalendarManager : MonoBehaviour
{
    [SerializeField] GameObject dateCellPrefab;
    [SerializeField] RectTransform dateContent;
    [SerializeField] Text yearText;
    [SerializeField] Text monthText;

    public List<DateCell> dateCells = new List<DateCell>();
    const int maxDate = 42;
    DateTime dateTime;

    // Start is called before the first frame update
    void Start()
    {
        dateTime = DateTime.Now;
        CreateDateCell();
        SetDate();
    }
    void CreateDateCell()
    {
        for (int i = 0; i < maxDate; i++)
        {
            DateCell dateCell = Instantiate(dateCellPrefab, dateContent).GetComponent<DateCell>();
            dateCells.Add(dateCell);
        }
        dateTime = DateTime.Now;
        //yearText.text = dateTime.Year.ToString();
        monthText.text = dateTime.Month.ToString(00+"월");
    }
    int GetDays(DayOfWeek day)
    {
        switch(day)
        {
            case DayOfWeek.Monday: return 1;
            case DayOfWeek.Tuesday: return 2;
            case DayOfWeek.Wednesday: return 3;
            case DayOfWeek.Thursday: return 4;
            case DayOfWeek.Friday: return 5;
            case DayOfWeek.Saturday: return 6;
            case DayOfWeek.Sunday: return 0;
        }
        return 0;
    }
    void SetDate()
    {
        DateTime firstDay = dateTime.AddDays(-(dateTime.Day - 1));
        int index = GetDays(firstDay.DayOfWeek);
        int date = 0;
        for (int i = 0; i < maxDate; i++)
        { 
            //dateCells[i].gameObject.SetActive(false);
            if (i >= index)
            {
                DateTime thatDay = firstDay.AddDays(date);
                if (thatDay.Month == firstDay.Month)
                {
                    Text label = dateCells[i].date;
                    dateCells[i].gameObject.SetActive(true);
                    label.text = (date + 1).ToString();
                    date++;
                }
            }
        }
    }
    public void YearPrev()
    {
        dateTime = dateTime.AddYears(-1);
        CreateDateCell();
    }

    public void YearNext()
    {
        dateTime = dateTime.AddYears(1);
        CreateDateCell();
    }

    public void MonthPrev()
    {
        dateTime = dateTime.AddMonths(-1);
        CreateDateCell();
    }

    public void MonthNext()
    {
        dateTime = dateTime.AddMonths(1);
        CreateDateCell();
    }
}