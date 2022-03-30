using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMDbApiLib.Models;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MovieList : MonoBehaviour
{
    [SerializeField] private ScrollContent scrollContent;
    [SerializeField] private NewMovieData movieData;
    [SerializeField] private GameObject posterPrefab;
    
    private static string apiKey = "k_mbctzad3";
    private static string inTheaters = "https://imdb-api.com/en/API/InTheaters/";
    async void Start()
    {
        await LoadMovieList(inTheaters);
    }

    async Task LoadMovieList(string api)
    {
        string json = await JsonService.Instance.GetJson(api + apiKey);
        NewMovieData movieData = JsonConvert.DeserializeObject<NewMovieData>(json);
        foreach (var movie in movieData.Items)
        {
            GameObject poster = Instantiate(posterPrefab, scrollContent.transform);
            Image image = poster.GetComponent<Image>();
            //TODO: error handling for poster download
            Davinci.get().load(movie.Image).into(image).start();
        }
        scrollContent.Init();
    }
}
