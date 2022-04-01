using System;
using TMPro;
using UnityEngine;

public class Date : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI day;
    [SerializeField] private TextMeshProUGUI date;

    private void Awake()
    {
        if (day && date)
            return;
        Debug.LogError("Missing serialization: "+name);
    }

    public void SetDate(DateTime dateTime)
    {
        day.text = string.Format("{0:ddd}", dateTime);
        date.text = dateTime.Day.ToString();
    }
}
