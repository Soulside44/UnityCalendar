using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateCell : MonoBehaviour
{
    [SerializeField] public Text dateText;
    [SerializeField] public Button button;
    [SerializeField] Text book;

    public string date;
    
    // Start is called before the first frame update
    private void Awake()
    {
        dateText.text = "";
    }
}
