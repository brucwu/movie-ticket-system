using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Date : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpDay;
    [SerializeField] private TextMeshProUGUI tmpDate;
    private DateTime date;
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnDateSelected);
        if (tmpDay && tmpDate)
            return;
        Debug.LogError("Missing serialization: "+name);
    }

    public void SetDate(DateTime dateTime)
    {
        tmpDay.text = string.Format("{0:ddd}", dateTime);
        tmpDate.text = dateTime.Day.ToString();
        date = dateTime;
        
        // Mock data range is only between 4/4 to 4/8
        if (date.Day < 4 || date.Day > 8)
            button.interactable = false;
        else
        {
            button.interactable = true;
        }
    }

    private void OnDateSelected()
    {
        SeatService.Instance.Date = date;
        AppService.Instance.ShowSeats();
    }
}
