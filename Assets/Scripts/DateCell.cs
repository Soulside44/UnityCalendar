using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateCell : MonoBehaviour
{
    [SerializeField] public Text date;
    [SerializeField] public Button button;
    [SerializeField] Text book;

    // Start is called before the first frame update
    private void Awake()
    {
        date.text = "";
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
