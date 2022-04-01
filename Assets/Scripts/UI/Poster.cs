using System;
using System.Runtime.CompilerServices;
using IMDbApiLib.Models;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class Poster : MonoBehaviour
{
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
        
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => AppService.Instance.ShowDetail(detail));
    }
}
