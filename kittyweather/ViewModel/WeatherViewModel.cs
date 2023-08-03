using CommunityToolkit.Mvvm.ComponentModel;

namespace kittyweather.ViewModel; 

public partial class WeatherViewModel : ObservableObject {
    [ObservableProperty] private string cityName = "Warsaw";
    [ObservableProperty] private string weatherDesc = "23°C, Windy";
}