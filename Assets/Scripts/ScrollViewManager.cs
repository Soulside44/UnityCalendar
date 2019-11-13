using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewManager : ViewManager
{
    [SerializeField] GameObject planCellPrefab;
    [SerializeField] RectTransform content;
    List<PlanCell> planCellList = new List<PlanCell>();
    float cellHight = 400f;
    PlanDatas? planDatas;

    private void Awake()
    {
        Initialize();
        title = "DoPlan!";
        leftNavgationViewButton = Instantiate(hambergerButtonPrefab).GetComponent<PlannerButton>();
        leftNavgationViewButton = Instantiate(CalendarButtonPrefab).GetComponent<PlannerButton>();
    }
    private void Start()
    {
        
    }
    void LoadData()
    {
        if(planDatas.HasValue)
        {
            PlanDatas plandatasValue = planDatas.Value;
        }
    }
    void AddCell(PlanData planData)
    {
        PlanCell planCell = Instantiate(planCellPrefab).GetComponent<PlanCell>();
  
    }
}
