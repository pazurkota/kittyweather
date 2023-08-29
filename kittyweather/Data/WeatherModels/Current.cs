using Newtonsoft.Json;

namespace kittyweather.Data;

// Get current weather state
public class Current {
    public Condition Condition { get; set; } = null!;
    [JsonProperty("air_quality")] public AirQuality AirQuality { get; set; } = null!;
    [JsonProperty("last_updated")] public string LastUpdated { get; set; } = null!;

    // celsius
    [JsonProperty("temp_c")] public decimal TemperatureC { get; set; }
    [JsonProperty("feelslike_c")] public decimal FeelsLikeC { get; set; }
    
    // fahrenheit
    [JsonProperty("temp_f")] public decimal TemperatureF { get; set; }
    [JsonProperty("feelslike_f")] public decimal FeelsLikeF { get; set; }
    
    // visibility
    [JsonProperty("vis_km")] public decimal VisibilityKm { get; set; }
    [JsonProperty("vis_miles")] public decimal VisibilityMiles { get; set; }
    
    public decimal WindSpeedsMs => Math.Round(WindSpeedKph / 3.6m, 1); // meters per second
    [JsonProperty("wind_kph")] public decimal WindSpeedKph { get; set; }
    [JsonProperty("wind_mph")] public decimal WindSpeedMph { get; set; }

    [JsonProperty("wind_dir")] public string WindDirection { get; set; } = null!;

    [JsonProperty("pressure_mb")] public decimal PressureMb { get; set; }
    [JsonProperty("pressure_in")] public decimal PressureIn { get; set; }
    
    [JsonProperty("precip_mm")] public decimal PrecipitationMm { get; set; }
    [JsonProperty("precip_in")] public decimal PrecipitationIn { get; set; }
    
    [JsonProperty("humidity")] public int Humidity { get; set; }
    [JsonProperty("cloud")] public int Cloud { get; set; }
    
    [JsonProperty("uv")] public decimal UvIndex { get; set; }
    [JsonProperty("is_day")] public int IsDay { get; set; }
}