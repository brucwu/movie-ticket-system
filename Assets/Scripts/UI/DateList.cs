using System;
using UnityEngine;

public class DateList : MonoBehaviour
{
    [SerializeField] private ScrollContent scrollContent;
    [SerializeField] private Date datePrefab;
    private void OnEnable()
    {
        //TODO: Get actual ShowTime data, instead of assuming movie is showing everyday in the next n days
        LoadDateList(30);
    }

    private void OnDisable()
    {
        ClearDateList();
    }

    private void LoadDateList(int daysAhead)
    {
        DateTime today = DateTime.Now;
        for (int i = 0; i < daysAhead; i++)
        {
            Date date = Instantiate(datePrefab, scrollContent.transform);
            date.SetDate(today.AddDays(i));
        }
        scrollContent.Init();
    }

    private void ClearDateList()
    {
        foreach (Transform child in scrollContent.transform)
        { 
            Destroy(child.gameObject);
        }
    }
}
