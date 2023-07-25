using kittyweather.Data;

namespace kittyweather.Pages; 

public partial class WeatherPage : ContentPage {
    private double latitude;
    private double longitude;
    
    public WeatherPage() {
        InitializeComponent();
    }

    protected override async void OnAppearing() {
        base.OnAppearing();
        await GetDeviceLocation();
        
        var apiService = new ApiService();

        try {
            var weather = apiService.GetWeather(latitude, longitude);

            CityName.Text = weather.Location.Name;
            WeatherDescription.Text = $"{weather.Current.TemperatureC}°C, {weather.Current.Condition.ConditionState}";
        }
        catch (UnauthorizedAccessException) {
            await DisplayAlert("Error Occured", "API Key is not set! Go to settings and enter your API Key", "OK");
        }
        catch (Exception e) {
            await DisplayAlert("Error Occured", e.Message, "OK");
        }
    }

    private async Task GetDeviceLocation() {
        var location = await Geolocation.GetLocationAsync();
        latitude = location.Latitude;
        longitude = location.Longitude;
    }
}