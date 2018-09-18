using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCycle : MonoBehaviour {

    public Text Day;
    public Text Month;
    public Text Year;

    public int DayCount = 1;
    public int MonthCount;
    public int YearCount;

    private void Start()
    {
        DayCount = 1;
        Day.text = DayCount.ToString();
}


    void DayCounter()
    {
        DayCount += 1;

        if(DayCount == 31)
        {
            DayCount = 0;
            MonthCounter();
        }

        Day.text = DayCount.ToString();
    }

    void MonthCounter()
    {
        MonthCount += 1;

    }
}
