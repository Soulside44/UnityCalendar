using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct PlanDatas
{
    public List<PlanData> planDataList;
    public PlanDatas(List<PlanData> planDatas)
    {
        this.planDataList = planDatas;
    }
}
public struct PlanData
{
    public string date;
    public string bookname;
    public int Dday;
    public int duration;
}

