using CommunityToolkit.Mvvm.ComponentModel;
using kittyweather.Data;

namespace kittyweather.ViewModel; 

public partial class WeatherViewModel : ObservableObject {
    [ObservableProperty] private Weather weather;

    public async Task GetWeatherData() {
        Weather data = await ApiService.GetWeather(52.237049, 21.017532);
        Weather = data;
    }
}