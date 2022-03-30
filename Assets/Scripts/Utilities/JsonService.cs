using System.Threading.Tasks;
using UnityEngine.Networking;

public class JsonService : Singleton<JsonService>
{
    public async Task<string> GetJson(string url)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        await webRequest.SendWebRequest();
        
        //TODO: implement error handling for fetching json
        return webRequest.downloadHandler.text;
    }
}
