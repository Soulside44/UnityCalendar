using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [HideInInspector] public string title;
    [HideInInspector] public string yearTitle;
    [HideInInspector] public string monthTitle;
    [HideInInspector] public MainManager mainManager;
    [SerializeField] protected GameObject rightButtonPrefab;
    [SerializeField] protected GameObject leftButtonPrefab;
    [SerializeField] protected GameObject hambergerButtonPrefab;
    [SerializeField] protected GameObject CalendarButtonPrefab;
    [HideInInspector] public PlannerButton leftNavgationViewButton;
    [HideInInspector] public PlannerButton rightNavgationViewButton;
    public void Initialize()
    {
        title = "";
        yearTitle = "";
        monthTitle = "";
    }
    public void Open(bool isAnimated=false)
    {
        if(isAnimated)
        {
            GetComponent<Animator>().SetTrigger("open");
        }
    }
    public void Close()
    {
        GetComponent<Animator>().SetTrigger("close");
    }
    public void DestroyViewManager()
    {
        Destroy(gameObject);
    }
}
