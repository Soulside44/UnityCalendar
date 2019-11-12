using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] NavigationManager navigationManager;
    public static MainManager Instance;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }
}
