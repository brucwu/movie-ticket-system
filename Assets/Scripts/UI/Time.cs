using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Time : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpTime;
    [SerializeField] private int index;
    [SerializeField] private string time;

    private void Awake()
    {
        tmpTime.text = time;
    }

    private void Update()
    {
        if (index != transform.GetSiblingIndex())
        {
            OnIndexChanged(transform.GetSiblingIndex());
        }
    }

    private void OnIndexChanged(int value)
    {
        index = value;
        //TODO: refactor hard coded mid-index
        if (index == 1)
        {
            transform.localScale = Vector3.one * 1.5f;
            SeatService.Instance.Time = time;
            SeatService.Instance.UpdateSeatingData();
        }
        else
        {
            transform.localScale = Vector3.one * 0.75f;
        }
    }
}
