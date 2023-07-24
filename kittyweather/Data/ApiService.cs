using RestSharp;

namespace kittyweather.Data;

interface IApiService {
    Task<Weather> GetWeather(string cityName);
}

public class ApiService : IApiService {
    private readonly string BASEURL = "https://api.weatherapi.com/v1/";
    
    public async Task<Weather> GetWeather(string cityName) {
        string apiKey = Preferences.Get("apiKey", "");

        if (string.IsNullOrEmpty(apiKey)) {
            throw new UnauthorizedAccessException("API Key is not set!");
        }
        
        var options = new RestClientOptions(BASEURL) {
            ThrowOnAnyError = true
        };
        
        var client = new RestClient(options);
        var request = new RestRequest($"forecast.json?key={apiKey}&q={cityName}&aqi=yes&alerts=yes&days=2");
        
        var response = await client.GetAsync<Weather>(request);

        return response;
    }
}