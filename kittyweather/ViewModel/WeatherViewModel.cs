using CommunityToolkit.Mvvm.ComponentModel;
using kittyweather.Data;

namespace kittyweather.ViewModel; 

public partial class WeatherViewModel : ObservableObject {
    [ObservableProperty] private Weather weather;
    [ObservableProperty] private string uvIndexDesc;

    public async Task GetWeatherData() {
        Weather data = await ApiService.GetWeather(52.237049, 21.017532);
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
}