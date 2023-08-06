using CommunityToolkit.Mvvm.ComponentModel;
using kittyweather.Data;

namespace kittyweather.ViewModel; 

public partial class WeatherViewModel : ObservableObject {
    [ObservableProperty] private Weather weather;
    [ObservableProperty] private List<Hour> hourlyWeather;
    [ObservableProperty] private string uvIndexDesc;

    public async Task GetWeatherData(double latitude, double longitude) {
        Weather data = await ApiService.GetWeather(latitude, longitude);
        Weather = data;
    }

    public void GetUvIndexDescription() {
        string uvIndexDesc = Weather.Current.UvIndex switch
        {
            < 3 => "Low",
            < 6 => "Moderate",
            < 8 => "High",
            < 11 => "Very High",
            _ => "Extreme"
        };

        UvIndexDesc = uvIndexDesc;
    }
    
    // @TODO Fix linq expression
    public void GetHourlyWeather() {
        var todayWeather = Weather.Forecast.ForecastDay[0].HourWeather;
        var tommorowWeather = Weather.Forecast.ForecastDay[1].HourWeather;

        var hourly = todayWeather.ToList();
        hourly.AddRange(tommorowWeather);

        // generate a linq expression that will sort the weather in the current timeframe and return 4 items
        var sortedHourly = hourly.Where(hour => hour.DateTime >= DateTime.Now && hour.DateTime <= DateTime.Now.AddHours(5)).OrderBy(hour => hour.Time).ToList();
        
        HourlyWeather = sortedHourly;
    }
}