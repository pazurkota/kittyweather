using kittyweather.Data;

namespace kittyweather.Pages; 

public partial class WeatherPage : ContentPage {
    public WeatherPage() {
        InitializeComponent();
    }

    protected override async void OnAppearing() {
        base.OnAppearing();
        var apiService = new ApiService();

        try {
            var weather = await apiService.GetWeather("auto:ip");

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
}