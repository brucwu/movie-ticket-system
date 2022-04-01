using System.Threading.Tasks;
using IMDbApiLib.Models;
using Newtonsoft.Json;
using UnityEngine;


public class MovieList : MonoBehaviour
{
    [SerializeField] private ScrollContent scrollContent;
    [SerializeField] private Poster posterPrefab;
    
    private static string apiKey = "k_mbctzad3";
    private static string inTheaters = "https://imdb-api.com/en/API/InTheaters/";
    
    private NewMovieData movieData;
    async void Start()
    {
        await LoadMovieList(inTheaters);
    }

    async Task LoadMovieList(string api)
    {
        string json = await JsonService.Instance.GetJson(api + apiKey);
        movieData = JsonConvert.DeserializeObject<NewMovieData>(json);
        foreach (var movie in movieData.Items)
        {
            Poster poster = Instantiate(posterPrefab, scrollContent.transform);
            movie.ImageData = poster.LoadImage(movie.Image);
        }
        scrollContent.Init();
    }
}
