﻿using RestSharp;
using Newtonsoft.Json;
using System.Net;

namespace kittyweather.Data;

public class ApiService {
    private static string BASEURL = "https://api.weatherapi.com/v1/";

    public static async Task<Weather> GetWeather(string cityName) {
        string apiKey = Preferences.Get("apiKey", null);

        if (string.IsNullOrEmpty(apiKey)) {
            throw new UnauthorizedAccessException("API Key is not set!");
        }

        var options = new RestClientOptions(BASEURL) {
            ThrowOnAnyError = true
        };

        var client = new RestClient(options);
        var request = new RestRequest($"forecast.json?key={apiKey}&q={cityName}&aqi=yes&alerts=yes&days=2");

        var response = await client.ExecuteAsync(request);
        var content = response.Content;

        if (response.StatusCode == HttpStatusCode.OK) {
            var weather = JsonConvert.DeserializeObject<Weather>(content);
            return weather;
        }

        return null;
    }

    public static async Task<Weather> GetWeather(double latitude, double longitude) {
        string apiKey = Preferences.Get("apiKey", null);

        if (string.IsNullOrEmpty(apiKey)) {
            throw new UnauthorizedAccessException("API Key is not set!");
        }

        var options = new RestClientOptions(BASEURL) {
            ThrowOnAnyError = true
        };

        var client = new RestClient(options);
        var request = new RestRequest($"forecast.json?key={apiKey}&q={latitude},{longitude}&aqi=yes&alerts=yes&days=2");

        var response = await client.ExecuteAsync(request);
        var content = response.Content;

        if (response.StatusCode == HttpStatusCode.OK) {
            var weather = JsonConvert.DeserializeObject<Weather>(content);
            return weather;
        }

        return null;
    }

    public static async Task<bool> CheckApiKey(string apiKey) {
        var options = new RestClientOptions(BASEURL) {
            ThrowOnAnyError = true
        };

        var client = new RestClient(options);
        var request = new RestRequest($"current.json?key={apiKey}&q=London&aqi=no");

        var response = await client.ExecuteAsync(request);

        if (response.StatusCode == HttpStatusCode.OK) {
            return true;
        }

        return false;
    }
}