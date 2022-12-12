using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenWeatherAPI;
using System.Threading.Tasks;
using TMPro;

public class WeatherController : MonoBehaviour
{
    private OpenWeatherApiClient weatherAPI;
    [SerializeField] private TextMeshProUGUI weatherText;
    [SerializeField] private TextAsset keyFile;

    private void Start()
    {
        weatherAPI = new OpenWeatherApiClient(keyFile.text);
    }

    private async Task<QueryResponse> ReportCurrentWeather(string place)
    {
        var query = await weatherAPI.QueryAsync(place);
        return query;
    }

    public async void SetWeatherText(string place)
    {
        var weather = await ReportCurrentWeather(place);

        weatherText.text = WeatherString(weather);
    }

    public string WeatherString(QueryResponse queryResponse)
    {
        return string.Format("The weather in {0}, {1} is currently {2} °C and {3}", queryResponse.Name, queryResponse.Sys.Country, queryResponse.Main.Temperature.CelsiusCurrent, GetFirstWord(queryResponse.WeatherList[0].Description));
    }

    public string GetFirstWord(string description)
    {
        return description.Split(' ')[0];
    }


}
