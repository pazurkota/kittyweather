using Newtonsoft.Json;

namespace kittyweather.Data; 

public class ForecastDay {
    [JsonProperty("day")] public Day Day { get; set; } = null!;
}

public class Day {
    // celsius
    [JsonProperty("avgtemp_c")] public decimal AvgTempC { get; set; }
    [JsonProperty("maxtemp_c")] public decimal MaxTempC { get; set; }
    [JsonProperty("mintemp_c")] public decimal MinTempC { get; set; }
    
    // fahrenheit
    [JsonProperty("avgtemp_f")] public decimal AvgTempF { get; set; }
    [JsonProperty("maxtemp_f")] public decimal MaxTempF { get; set; }
    [JsonProperty("mintemp_f")] public decimal MinTempF { get; set; }
    
    // visibility
    [JsonProperty("avgvis_km")] public decimal AvgVisibilityKm { get; set; }
    [JsonProperty("avgvis_miles")] public decimal AvgVisibilityMiles { get; set; }
    
    [JsonProperty("maxwind_kph")] public decimal MaxWindSpeedKph { get; set; }
    [JsonProperty("maxwind_mph")] public decimal MaxWindSpeedMph { get; set; }
    
    [JsonProperty("totalprecip_mm")] public decimal PrecipitationMm { get; set; }
    [JsonProperty("totalprecip_in")] public decimal PrecipitationIn { get; set; }
    
    [JsonProperty("daily_chance_of_rain")] public decimal ChanceOfRain { get; set; }
    [JsonProperty("daily_chance_of_snow")] public decimal ChanceOfSnow { get; set; }
    
    [JsonProperty("uv")] public decimal UvIndex { get; set; }
    
    [JsonProperty("condition")] public Condition Condition { get; set; } = null!;
}

public class Forecast {
    [JsonProperty("forecastday")] public List<ForecastDay> ForecastsDay { get; set; } = null!;
}