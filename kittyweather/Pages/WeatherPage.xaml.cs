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
    
    private async Task GetDeviceLocation() {
        var location = await Geolocation.GetLocationAsync();
        latitude = location.Latitude;
        longitude = location.Longitude;
    }

    protected override async void OnAppearing() {
        base.OnAppearing();
        await GetDeviceLocation();

        try {
            var viewModel = (WeatherViewModel)BindingContext;
            await viewModel.GetWeatherData(latitude, longitude);

            viewModel.GetUvIndexDescription();
            viewModel.GetHourlyWeather();

            viewModel.GetTemperature();
            viewModel.GetVisibility();
            viewModel.GetAirPressure();
            viewModel.GetPrecipitation();
            viewModel.SetWeatherIcon();
            viewModel.GetWindSpeed();
            
            var alert = viewModel.Weather.Alerts.WeatherAlerts.FirstOrDefault();

            if (alert != null) {
                WeatherAlertBox.IsVisible = true;
                WeatherAlertDesc.Text = alert.AlertHeadline;
            }
            else {
                WeatherAlertBox.IsVisible = false;
            }
        }
        catch (UnauthorizedAccessException) {
            await DisplayAlert("Error", "Unable to download data: Please set the API Key in settings.", "OK");
        } catch (Exception) {
            await DisplayAlert("Error", "Unable to download data: Please try again later.", "OK");
        }   
    }
    
    private async void SearchCity(object sender, EventArgs e)
    {
        try {
            var city = ((Entry)sender).Text;

            var viewModel = (WeatherViewModel)BindingContext;
            await viewModel.GetWeatherData(city);

            viewModel.GetUvIndexDescription();
            viewModel.GetHourlyWeather();

            viewModel.GetTemperature();
            viewModel.GetVisibility();
            viewModel.GetAirPressure();
            viewModel.GetPrecipitation();
            viewModel.SetWeatherIcon();
            viewModel.GetWindSpeed();

            var alert = viewModel.Weather.Alerts.WeatherAlerts.FirstOrDefault();

            if (alert != null) {
                WeatherAlertBox.IsVisible = true;
                WeatherAlertDesc.Text = alert.AlertHeadline;
            } else {
                WeatherAlertBox.IsVisible = false;
            }
        } catch (UnauthorizedAccessException) {
            await DisplayAlert("Error", "Unable to download data: Please set the API Key in settings.", "OK");
        } catch (Exception) {
            await DisplayAlert("Error", "Unable to download data: Please try again later.", "OK");
        }
    }

    private async void ShowMoreAlertClicked(object sender, EventArgs e) {
        var alert = ((WeatherViewModel)BindingContext).Weather.Alerts.WeatherAlerts.FirstOrDefault();
        
        await DisplayAlert("Weather Alert", $"{alert.AlertHeadline}:\n\n{alert.AlertDescription}", "OK");
    }
}