using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatList : MonoBehaviour
{
    [SerializeField] private GameObject chart;
    
    public void LoadSeatList()
    {
        chart.SetActive(false);
        chart.SetActive(true);
    }

    private void OnEnable()
    {
        SeatService.Instance.UpdateSeatingData();
    }
}
