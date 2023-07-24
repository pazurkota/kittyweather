using RestSharp;
using Newtonsoft.Json;

namespace kittyweather.Data;

interface IApiService {
    Weather GetWeather(string cityName);
}

public class ApiService : IApiService {
    private readonly string BASEURL = "https://api.weatherapi.com/v1/";
    
    public Weather GetWeather(string cityName) {
        string apiKey = Preferences.Get("apiKey", null);

        if (string.IsNullOrEmpty(apiKey)) {
            throw new UnauthorizedAccessException("API Key is not set!");
        }
        
        var options = new RestClientOptions(BASEURL) {
            ThrowOnAnyError = true
        };
        
        var client = new RestClient(options);
        var request = new RestRequest($"forecast.json?key={apiKey}&q={cityName}&aqi=yes&alerts=yes&days=2");

        var response = client.ExecuteAsync(request).Result.Content;
        var weather = JsonConvert.DeserializeObject<Weather>(response);
        
        return weather;
    }
    
    public Weather GetWeather(double latitude, double longitude) {
        string apiKey = Preferences.Get("apiKey", "");

        if (string.IsNullOrEmpty(apiKey)) {
            throw new UnauthorizedAccessException("API Key is not set!");
        }
        
        var options = new RestClientOptions(BASEURL) {
            ThrowOnAnyError = true
        };
        
        var client = new RestClient(options);
        var request = new RestRequest($"forecast.json?key={apiKey}&q={latitude},{longitude}&aqi=yes&alerts=yes&days=2");
        
        var response = client.ExecuteAsync(request).Result.Content;
        var weather = JsonConvert.DeserializeObject<Weather>(response);
        
        return weather;
    }
}