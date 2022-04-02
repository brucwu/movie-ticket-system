using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Purchase : MonoBehaviour
{
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnPurchased);
    }

    private void OnPurchased()
    {
        SeatService.Instance.UploadSeatingData();
        AppService.Instance.ShowConfirmation();
    }
}
