using TMPro;
using UnityEngine;

public class Confirmation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpTitle;
    [SerializeField] private TextMeshProUGUI tmpDateTime;

    public void SetDateTime(string dateTime)
    {
        tmpDateTime.text = dateTime;
    }

    public void SetTitle(string title)
    {
        tmpTitle.text = title;
    }
}
