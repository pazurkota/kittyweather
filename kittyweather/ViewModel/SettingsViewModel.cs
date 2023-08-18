using CommunityToolkit.Mvvm.ComponentModel;

namespace kittyweather.ViewModel; 

public partial class SettingsViewModel : ObservableObject {
    [ObservableProperty] private string selectedTemperatureUnit;
    [ObservableProperty] private string selectedVisibilityUnit;
    [ObservableProperty] private string selectedAirPressureUnit;
    [ObservableProperty] private string selectedPrecipitationUnit;

    // Weather units:
    //
    // Temperature: "temperatureUnit" (Celsius, Fahrenheit)
    // Visibility: "visibilityUnit" (Kilometers, Miles)
    // Air Pressure: "airPressureUnit" (Millibars, Inches)
    // Precipitation: "precipitationUnit" (Millimeters, Inches)

    public SettingsViewModel() {
        SelectedTemperatureUnit = Preferences.Get("temperatureUnit", "Celsius");
        SelectedVisibilityUnit = Preferences.Get("visibilityUnit", "Kilometers");
        SelectedAirPressureUnit = Preferences.Get("airPressureUnit", "Millibars");
        SelectedPrecipitationUnit = Preferences.Get("precipitationUnit", "Millimeters");
    }

    public List<string> TemperatureOptions { get; } = new() {
        "Celsius",
        "Fahrenheit"
    };

    public List<string> VisibilityOptions { get; } = new() {
        "Kilometers",
        "Miles"
    };

    public List<string> AirPressureOptions { get; } = new() {
        "Millibars",
        "Inches"
    };

    public List<string> PrecipitationOptions { get; } = new() {
        "Millimeters",
        "Inches"
    };
}