using Newtonsoft.Json;

namespace kittyweather.Data; 

// A single Alert Class
public class Alert {
    [JsonProperty("headline")] public string AlertHeadline { get; set; } = null!;
}

// A class for multiple weather alerts
public class Alerts {
    [JsonProperty("alert")] public List<Alert> WeatherAlerts { get; set; } = null!;
}