using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class CalendarViewManager : ViewManager
{
    [SerializeField] GameObject dateCellPrefab;
    [SerializeField] RectTransform dateContent;
    public delegate void reNewYearMonth(string year, string month);
    public reNewYearMonth reNewYearMonthDelegate;
    public List<DateCell> dateCells = new List<DateCell>();
    const int maxDate = 42;
    DateTime dateTime;

    // Start is called before the first frame update
    private void Awake()
    {
        dateTime = DateTime.Now;
        CreateDateCell();
        SetDate();
        SetYearMonth();

        leftNavgationViewButton = Instantiate(leftButtonPrefab).GetComponent<PlannerButton>();
        leftNavgationViewButton.SetOnClickAction(() =>
        {
            MonthPrev();
        });
        rightNavgationViewButton = Instantiate(rightButtonPrefab).GetComponent<PlannerButton>();
        rightNavgationViewButton.SetOnClickAction(() =>
        {
            MonthNext();
        });
    }
    private void Start()
    {

    }
    void CreateDateCell()
    {
        for (int i = 0; i < maxDate; i++)
        {
            DateCell dateCell = Instantiate(dateCellPrefab, dateContent).GetComponent<DateCell>();
            dateCells.Add(dateCell);
        }    
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
                    dateCells[i].gameObject.SetActive(true);
                    dateCells[i].dateText.text = (date + 1).ToString();
                    date++;
                }
            }
        }
        
    }
    public void YearPrev()
    {
        ClearCell();
        dateTime = dateTime.AddYears(-1);
        CreateDateCell();
        SetDate();
        SetYearMonth();
    }

    public void YearNext()
    {
        ClearCell();
        dateTime = dateTime.AddYears(1);
        CreateDateCell();
        SetDate();
        SetYearMonth();
    }

    public void MonthPrev()
    {
        ClearCell();
        dateTime = dateTime.AddMonths(-1);
        CreateDateCell();
        SetDate();
        SetYearMonth();
    }

    public void MonthNext()
    {
        ClearCell();
        dateTime = dateTime.AddMonths(1);
        CreateDateCell();
        SetDate();
        SetYearMonth();
    }
    public void ClearCell()
    {
        foreach(DateCell dateCell in dateCells)
        {
            Destroy(dateCell.gameObject);
        }
        dateCells.Clear();
    }
    public void SetYearMonth()
    {
        monthTitle = dateTime.ToString("MMMM", CultureInfo.GetCultureInfo("en"));
        yearTitle = dateTime.ToString("yyyy", CultureInfo.GetCultureInfo("en"));
        reNewYearMonthDelegate?.Invoke(yearTitle, monthTitle);
    }
}
