using System;
using System.Collections;
using System.Collections.Generic;
using IMDbApiLib.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MovieDetail : MonoBehaviour
{
    public NewMovieDataDetail Detail;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image poster;
    private void OnEnable()
    {
        title.text = Detail.Title;
        description.text = Detail.Plot;
        poster.sprite = Detail.Sprite;
    }
}
