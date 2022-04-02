using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class Seat : MonoBehaviour
{
    [SerializeField] private string id;
    [SerializeField] private Status status;
    private Toggle toggle;
    public enum Status
    {
        Availiable = 0,
        Sold = 1,
        Selected = 2
    }

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener((selected)=>OnSeatToggled(selected));
    }

    private void OnEnable()
    {
        gameObject.name = id;
        toggle.enabled = true;
        toggle.targetGraphic.color = Color.white;
        if(SeatService.Instance.Data?[id] != null)
            UpdateStatus((Status)int.Parse(SeatService.Instance.Data[id].value));
    }
    
    private void UpdateStatus(Status value)
    {
        status = value;
        switch (status)
        {
            case Status.Availiable:
                toggle.enabled = true;
                toggle.targetGraphic.color = Color.white;
                break;
            case Status.Selected:
                toggle.enabled = true;
                toggle.targetGraphic.color = Color.red;
                break;
            case Status.Sold:
                toggle.enabled = false;
                toggle.targetGraphic.color = Color.gray;
                break;
        }
        SeatService.Instance.Data[id].value = ((int) status).ToString();
    }

    public void OnSeatToggled(bool selected)
    {
        if (selected)
            UpdateStatus(Status.Selected);
        else
            UpdateStatus(Status.Availiable);
    }
}
