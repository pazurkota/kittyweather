using kittyweather.Data;
using kittyweather.ViewModel;

namespace kittyweather.Pages; 

public partial class WeatherPage : ContentPage 
{
    public WeatherPage() 
    {
        InitializeComponent();
        BindingContext = new WeatherViewModel();
    }

    protected override async void OnAppearing() 
    {
        base.OnAppearing();

        var viewModel = (WeatherViewModel)BindingContext;
        await viewModel.GetLocationWeatherData();
    }

    async void SearchCity(object sender, EventArgs e)
    {
        string cityName = ((Entry)sender).Text;

        var viewModel = (WeatherViewModel)BindingContext;
        await viewModel.GetCityWeatherData(cityName);
    }
    
    async void ShowMoreAlertClicked(object sender, EventArgs e) 
    {
        var alert = ((WeatherViewModel)BindingContext).Weather.Alerts.WeatherAlerts.FirstOrDefault();
        
        await DisplayAlert("Weather Alert", $"{alert.AlertHeadline}:\n\n{alert.AlertDescription}", "OK");
    }
}