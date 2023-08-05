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

    public void GetHourlyWeather() {
        HourlyWeather = Weather.Forecast.ForecastDay[0].HourWeather;
    }
}