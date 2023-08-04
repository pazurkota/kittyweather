using kittyweather.Data;
using kittyweather.ViewModel;

namespace kittyweather.Pages; 

public partial class WeatherPage : ContentPage {
    private double latitude;
    private double longitude;

    public WeatherPage() {
        InitializeComponent();
        BindingContext = new WeatherViewModel();
    }

    protected override async void OnAppearing() {
        base.OnAppearing();

        var viewModel = (WeatherViewModel) BindingContext;
        await viewModel.GetWeatherData();

        viewModel.GetUvIndexDescription();
    }

    private async Task GetDeviceLocation() {
        var location = await Geolocation.GetLocationAsync();
        latitude = location.Latitude;
        longitude = location.Longitude;
    }

    private async void ShowWeatherAlert() {
        var data = await ApiService.GetWeather(latitude, longitude);
        var alert = data.Alerts.WeatherAlerts.FirstOrDefault();

        if (alert is not null) {
            WeatherAlertBox.IsVisible = true;
            WeatherAlertDesc.Text = $"{alert.AlertHeadline}";
        }
    }
}