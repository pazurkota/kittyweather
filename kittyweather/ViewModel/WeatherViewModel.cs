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
    
    [ObservableProperty] private string windSpeed;
    
    [ObservableProperty] private string weatherIcon;

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
            
            hour.WeatherIcon = "Images/Day/" + GetWeatherIcon()[hour.Condition.ConditionCode];
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

    public void GetWindSpeed() {
        var unit = _settingsViewModel.SelectedWindSpeedUnit;
        
    switch (unit) {
            case "KPH":
                WindSpeed = $"{Weather.Current.WindSpeedKph}kph";
                break;
            case "MPH":
                WindSpeed = $"{Weather.Current.WindSpeedMph}mph";
                break;
            case "M/S":
                WindSpeed = $"{Weather.Current.WindSpeedsMs}m/s";
                break;
        }
    }

    public void SetWeatherIcon() {
        WeatherIcon = "Images/Day/" + GetWeatherIcon()[Weather.Current.Condition.ConditionCode];
    } 
    
    private Dictionary<int, string> GetWeatherIcon() {
        var dictionary = new Dictionary<int, string> {
            {1000, "sunny.svg"},
            {1003, "partly_cloudy.svg"},
            {1006, "cloudy.svg"},
            {1009, "overcast.svg"},
            {1030, "fog.svg"},
            {1063, "showers.svg"},
            {1066, "snow.svg"},
            {1069, "snow.svg"},
            {1072, "snow.svg"},
            {1087, "thunderstorm.svg"},
            {1114, "snow.svg"},
            {1117, "snow.svg"},
            {1135, "fog.svg"},
            {1147, "snow.svg"},
            {1150, "showers.svg"},
            {1153, "showers.svg"},
            {1168, "showers.svg"},
            {1171, "showers.svg"},
            {1180, "showers.svg"},
            {1183, "showers.svg"},
            {1186, "showers.svg"},
            {1189, "showers.svg"},
            {1192, "showers.svg"},
            {1195, "showers.svg"},
            {1198, "showers.svg"},
            {1201, "showers.svg"},
            {1204, "showers.svg"},
            {1207, "showers.svg"},
            {1210, "showers.svg"},
            {1213, "snow.svg"},
            {1216, "snow.svg"},
            {1219, "snow.svg"},
            {1222, "snow.svg"},
            {1225, "snow.svg"},
            {1237, "thunderstorm.svg"},
            {1240, "showers.svg"},
            {1243, "showers.svg"},
            {1246, "showers.svg"},
            {1249, "showers.svg"},
            {1252, "showers.svg"},
            {1255, "showers.svg"},
            {1258, "showers.svg"},
            {1261, "showers.svg"},
            {1264, "showers.svg"},
            {1273, "thunderstorm.svg"},
            {1276, "thunderstorm.svg"},
            {1279, "thunderstorm.svg"},
            {1282, "thunderstorm.svg"}
        };

        return dictionary;
    }
}