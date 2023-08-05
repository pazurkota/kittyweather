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
        await GetDeviceLocation();

        try {
            var viewModel = (WeatherViewModel)BindingContext;
            await viewModel.GetWeatherData(latitude, longitude);

            viewModel.GetUvIndexDescription();
        }
        catch (UnauthorizedAccessException) {
            await DisplayAlert("Error", "Unable to download data: Please set the API Key in settings.", "OK");
        }
        catch (Exception) {
            await DisplayAlert("Error", "Unable to download data: Please try again later.", "OK");
        }   
    }

    private async Task GetDeviceLocation() {
        var location = await Geolocation.GetLocationAsync();
        latitude = location.Latitude;
        longitude = location.Longitude;
    }
}