using Newtonsoft.Json;

namespace kittyweather.Data;

public class Forecast {
    [JsonProperty("forecastday")] public List<ForecastDay> ForecastDay { get; set; }
}

public class ForecastDay {
    [JsonProperty("hour")] public List<Hour> HourWeather { get; set; }
}

public class Hour {
    [JsonProperty("time")] public string Time { get; set; }
    public string ParsedTime => DateTime.Parse(Time).ToShortTimeString();
    [JsonProperty("temp_c")] public double TemperatureC { get; set; }
    [JsonProperty("temp_f")] public double TemperatureF { get; set; }
    [JsonProperty("condition")] public Condition Condition { get; set; }
}