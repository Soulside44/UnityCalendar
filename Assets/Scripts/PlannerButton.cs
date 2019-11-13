using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlannerButton : MonoBehaviour
{
    Button cachedButton;

    public Button CachedButton
    {
        get
        {
            if(cachedButton==null)
            {
                cachedButton = GetComponent<Button>();
            }
            return cachedButton;
        }
    }
    public void SetTitle(string title)
    {
        GetComponent<Text>().text = title;
    }
    public void SetOnClickAction(UnityAction action)
    {
        GetComponent<Button>().onClick.AddListener(action);
    }
    public void SetInteractable(bool value)
    {
        CachedButton.interactable = value;
    }
}
