using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    [SerializeField] NavigationManager navigationManager;
    [SerializeField] GameObject CalendarViewPrefab;
    [SerializeField] RectTransform content;
    //Stack<ViewManager>
    public static MainManager Instance;
    Stack<ViewManager> viewManagers = new Stack<ViewManager>();
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        CalendarViewManager calendarViewManager = Instantiate(CalendarViewPrefab, content).GetComponent<CalendarViewManager>();
        PresentView(calendarViewManager);
        calendarViewManager.reNewYearMonthDelegate = navigationManager.SetYearMonth;

    }
    public void PresentView(ViewManager viewManager)
    {
        viewManager.transform.SetParent(content);
        viewManager.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        viewManager.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        viewManager.GetComponent<RectTransform>().localScale = Vector3.one;
        if(viewManagers.Count>0)
        {
            viewManager.Open(true);
        }
        viewManager.mainManager = this;
        //네비바 이름 및 날짜 설정
        navigationManager.Title = viewManager.title;
        navigationManager.Year = viewManager.yearTitle;
        navigationManager.Month = viewManager.monthTitle;
        if (viewManager.rightNavgationViewButton)
        {
            viewManager.rightNavgationViewButton.transform.SetParent(navigationManager.RightButtonArea);
            viewManager.rightNavgationViewButton.GetComponent<RectTransform>().anchoredPosition
                = Vector2.zero;
        }

        // 왼쪽 Navigation button 표시
        if (viewManager.leftNavgationViewButton)
        {
            viewManager.leftNavgationViewButton.transform.SetParent(navigationManager.LeftButtonArea);
            viewManager.leftNavgationViewButton.GetComponent<RectTransform>().anchoredPosition
                = Vector2.zero;
        }
        if (viewManagers.Count > 0)
        {
            ViewManager oldViewManager = viewManagers.Peek();
            if (oldViewManager.rightNavgationViewButton)
            {
                oldViewManager.rightNavgationViewButton.gameObject.SetActive(false);
            }
            if (oldViewManager.leftNavgationViewButton)
            {
                oldViewManager.leftNavgationViewButton.gameObject.SetActive(false);
            }
        }
        // ViewManager를 관리대상으로 추가
        viewManagers.Push(viewManager);

        // Back Button 활성화 여부 확인
        CheckBackButton();
    }
    public void DismissViewManager(bool isAnimated = false)
    {
        ViewManager viewManager = viewManagers.Pop();

        viewManager.Close();

        // Destroy(viewManager.gameObject);

        // 마지막 화면이 사라지면서 이전 화면의 타이틀 표시
        ViewManager lastViewManager = viewManagers.Peek();
        navigationManager.Title = lastViewManager.title;
        navigationManager.Year = lastViewManager.yearTitle;
        navigationManager.Month = lastViewManager.monthTitle;
        // 이전 화면의 Navigation Button을 활성화
        if (lastViewManager.rightNavgationViewButton)
        {
            lastViewManager.rightNavgationViewButton.gameObject.SetActive(true);
        }
        if (lastViewManager.leftNavgationViewButton)
        {
            lastViewManager.leftNavgationViewButton.gameObject.SetActive(true);
        }

        // Back Button 활성화 여부 확인
        CheckBackButton();
    }
    void CheckBackButton()
    {
        //// Back 버튼 추가여부 확인
        //if (viewManagers.Count > 1)
        //{
        //    navigationManager.ShowBackButton(true);
        //}
        //else
        //{
        //    navigationManager.ShowBackButton(false);
        //}
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
