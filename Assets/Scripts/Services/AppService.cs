
using IMDbApiLib.Models;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AppService : Service<AppService>
{
    [SerializeField] private MovieList movieList;
    [SerializeField] private MovieDetail movieDetail;
    
    private static string triggerDetail = "ShowDetail";
    private static string triggerSeats = "ShowSeats";
    private static string triggerConfirmation = "ShowConfirmation";
    private static string triggerBack = "Back";
    
    private Animator appState;

    public override void Init()
    {
        appState = GetComponent<Animator>();
    }

    public void Back()
    {
        appState.SetTrigger(triggerBack);
    }

    public void ShowConfirmation()
    {
        appState.SetTrigger(triggerConfirmation);
    }
    public void ShowSeats()
    {
        appState.SetTrigger(triggerSeats);
    }
    public void ShowDetail(NewMovieDataDetail detail)
    {
        movieDetail.Detail = detail;
        appState.SetTrigger(triggerDetail);        
    }
}
