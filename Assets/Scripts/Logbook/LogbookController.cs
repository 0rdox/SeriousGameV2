using System;
using UnityEngine;
using UnityEngine.UI;

public class LogbookController : MonoBehaviour
{
    public Text[] pointTexts;
    private DateTime startTime;
  
    void Start()
    {
        startTime = DateTime.Now;
        UpdateText(startTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateText(DateTime tm) {
        for (int i = 0; i < pointTexts.Length; i++) {
            pointTexts[i].text = tm.Day.ToString();
            tm = tm.AddDays(1);
        }
    }

    public void AddWeek() {
        startTime = startTime.AddDays(7);
        UpdateText(startTime);
    }

    public void RemoveWeek() {
        startTime = startTime.AddDays(-7);
        UpdateText(startTime);
    }
}
