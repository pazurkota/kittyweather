using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using kittyweather.Data;

namespace kittyweather.ViewModel;

public partial class WeatherViewModel : ObservableObject
{
    double latitude;
    double longitude;
    
    readonly SettingsViewModel _settingsViewModel = new();

    [ObservableProperty] Weather weather;
    [ObservableProperty] List<Hour> hourlyWeather;
    [ObservableProperty] bool showAlert;
    
    [ObservableProperty] string temperature;
    [ObservableProperty] string visibility;
    [ObservableProperty] string visibilityDesc;
    [ObservableProperty] string airPressure;
    [ObservableProperty] string airPressureDesc;
    [ObservableProperty] string precipitation;
    [ObservableProperty] string precipitationDesc;
    [ObservableProperty] string uvIndexDesc;
    [ObservableProperty] string windSpeed;
    [ObservableProperty] string windSpeedDesc;
    [ObservableProperty] string weatherIcon;
    [ObservableProperty] string alertDesc;

    async Task GetWeatherData(double latitude, double longitude) {
        Weather data = await ApiService.GetWeather(latitude, longitude);
        Weather = data;
    }

    async Task GetWeatherData(string city)
    {
        Weather data = await ApiService.GetWeather(city);
        Weather = data;
    }

    void GetUvIndexDescription() {
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
    
    void GetHourlyWeather() {
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

            int iconCode = hour.Condition.ConditionCode;
            hour.WeatherIcon = "Images/Day/" + IconDictionary.GetWeatherIcon()[iconCode];
        }

        HourlyWeather = sortedHourly;
    }
    
    void GetTemperature() {
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

    void GetVisibility() {
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

    void GetAirPressure() {
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

    void GetPrecipitation()
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

    void GetWindSpeed() {
        var unit = _settingsViewModel.SelectedWindSpeedUnit;
        
        switch (unit) {
            case "KPH":
                WindSpeed = $"{Weather.Current.WindSpeedKph}";
                WindSpeedDesc = "kph";
                break;
            case "MPH":
                WindSpeed = $"{Weather.Current.WindSpeedMph}";
                WindSpeedDesc = "mph";
                break;
            case "M/S":
                WindSpeed = $"{Weather.Current.WindSpeedsMs}";
                WindSpeedDesc = "m/s";
                break;
        }
    }

    void SetWeatherIcon()
    {
        int iconCode = Weather.Current.Condition.ConditionCode;
        WeatherIcon = "Images/Day/" + IconDictionary.GetWeatherIcon()[iconCode];
    } 
    
    public async Task GetLocationWeatherData()
    {
        try
        {
            var location = await Geolocation.GetLocationAsync();
            
            latitude = location.Latitude;
            longitude = location.Longitude;

            await GetWeatherData(latitude, longitude);
        
            GetHourlyWeather();
            GetUvIndexDescription();
            GetTemperature();
            GetVisibility();
            GetAirPressure();
            GetPrecipitation();
            SetWeatherIcon();
            GetWindSpeed();
        
            var alert = Weather.Alerts.WeatherAlerts.FirstOrDefault();
        
            if (alert != null) {
                ShowAlert = true;
                AlertDesc = alert.AlertHeadline;
            } else {
                ShowAlert = false;
            }
        }
        catch (UnauthorizedAccessException) {
            await Shell.Current.DisplayAlert("Error", "Unable to download data: Please set the API Key in settings.", "OK");
        } catch (Exception) {
            await Shell.Current.DisplayAlert("Error", "Unable to download data: Please try again later.", "OK");
        }   
    }
    
    public async Task GetCityWeatherData(string city)
    {
        try
        {
            await GetWeatherData(city);
        
            GetHourlyWeather();
            GetUvIndexDescription();
            GetTemperature();
            GetVisibility();
            GetAirPressure();
            GetPrecipitation();
            SetWeatherIcon();
            GetWindSpeed();
        
            var alert = Weather.Alerts.WeatherAlerts.FirstOrDefault();
        
            if (alert != null) {
                ShowAlert = true;
                AlertDesc = alert.AlertHeadline;
            } else {
                ShowAlert = false;
            }
        }
        catch (UnauthorizedAccessException) {
            await Shell.Current.DisplayAlert("Error", "Unable to download data: Please set the API Key in settings.", "OK");
        } catch (Exception) {
            await Shell.Current.DisplayAlert("Error", "Unable to download data: Please try again later.", "OK");
        }   
    }
}