using CommunityToolkit.Mvvm.ComponentModel;
using kittyweather.Data;

namespace kittyweather.ViewModel;

public partial class WeatherViewModel : ObservableObject
{
    private readonly SettingsViewModel _settingsViewModel = new();

    [ObservableProperty] private Weather weather;
    [ObservableProperty] private List<Hour> hourlyWeather;

    [ObservableProperty] private string temperature;

    [ObservableProperty] private string visibility;
    [ObservableProperty] private string visibilityDesc;

    [ObservableProperty] private string airPressure;
    [ObservableProperty] private string airPressureDesc;

    [ObservableProperty] private string precipitation;
    [ObservableProperty] private string precipitationDesc;

    [ObservableProperty] private string uvIndexDesc;

    public async Task GetWeatherData(double latitude, double longitude) {
        Weather data = await ApiService.GetWeather(latitude, longitude);
        Weather = data;
    }

    public async Task GetWeatherData(string city)
    {
        Weather data = await ApiService.GetWeather(city);
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
        var unit = _settingsViewModel.SelectedTemperatureUnit;

        var hourly = Weather.Forecast.ForecastDay[0].HourWeather;
        hourly.AddRange(Weather.Forecast.ForecastDay[1].HourWeather);
        
        var currentTime = Weather.Location.LocalTimeParsed;
        
        var sortedHourly = hourly.Where(hour => hour.DateTime >= currentTime && hour.DateTime <= currentTime.AddHours(5)).OrderBy(hour => hour.Time).ToList();

        foreach (var hour in sortedHourly) {
            switch (unit) {
                case "Celsius":
                    hour.Temperature = $"{hour.TemperatureC}°C";
                    break;
                case "Fahrenheit":
                    hour.Temperature = $"{hour.TemperatureF}°F";
                    break;
            }
        }

        HourlyWeather = sortedHourly;
    }
    
    public void GetTemperature() {
        var unit = _settingsViewModel.SelectedTemperatureUnit;

        switch (unit) {
            case "Celsius":
                Temperature = $"{Weather.Current.TemperatureC}°C, {Weather.Current.Condition.ConditionState}";
                break;
            case "Fahrenheit":
                Temperature = $"{Weather.Current.TemperatureF}°F, {Weather.Current.Condition.ConditionState}";
                break;
        }
    }

    public void GetVisibility() {
        var unit = _settingsViewModel.SelectedVisibilityUnit;

        switch (unit) {
            case "Kilometers":
                Visibility = $"{Weather.Current.VisibilityKm}";
                VisibilityDesc = "km";
                break;
            case "Miles":
                Visibility = $"{Weather.Current.VisibilityMiles}";
                VisibilityDesc = "miles";
                break;
        }
    }

    public void GetAirPressure() {
        var unit = _settingsViewModel.SelectedAirPressureUnit;

        switch (unit)
        {
            case "Millibars":
                AirPressure = $"{Weather.Current.PressureMb}";
                AirPressureDesc = "mbar";
                break;
            case "Inches":
                AirPressure = $"{Weather.Current.PressureIn}";
                AirPressureDesc = "inches";
                break;
        }
    }

    public void GetPrecipitation()
    {
        var unit = _settingsViewModel.SelectedPrecipitationUnit;

        switch (unit)
        {
            case "Millimeters":
                Precipitation = $"{Weather.Current.PrecipitationMm}";
                PrecipitationDesc = "mm";
                break;
            case "Inches":
                Precipitation = $"{Weather.Current.PrecipitationIn}";
                PrecipitationDesc = "inches";
                break;
        }
    }   
}