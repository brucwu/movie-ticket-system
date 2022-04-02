using System;
using System.Runtime.CompilerServices;
using IMDbApiLib.Models;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class Poster : MonoBehaviour
{
    [SerializeField] private GameObject blocker;
    private Image image;
    private Button button;
    private NewMovieDataDetail dataDetail;
    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    public void Initialize(NewMovieDataDetail detail)
    {
        dataDetail = detail;
        
        //TODO: error handling for poster download
        Davinci.get().load(dataDetail.Image).into(image).start();
        dataDetail.Sprite = image.sprite;
        
        //Seating Database only have mock data for Morbious
        if (detail.Title != "Morbius")
        {
            blocker.SetActive(true);
            return;
        }
        blocker.SetActive(false);
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            AppService.Instance.ShowDetail(detail);
            SeatService.Instance.Movie = detail.Title;
        });
    }
}
