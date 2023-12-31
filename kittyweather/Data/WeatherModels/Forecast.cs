﻿using Newtonsoft.Json;

namespace kittyweather.Data;

public class Forecast {
    [JsonProperty("forecastday")] public List<ForecastDay> ForecastDay { get; set; }
}

public class ForecastDay {
    [JsonProperty("hour")] public List<Hour> HourWeather { get; set; }
    [JsonProperty("astro")] public Astronomy Astro { get; set; }
}

public class Hour {
    [JsonProperty("time")] public string Time { get; set; }
    [JsonProperty("condition")] public Condition Condition { get; set; }
    [JsonProperty("temp_c")] public double TemperatureC { get; set; }
    [JsonProperty("temp_f")] public double TemperatureF { get; set; }
    
    public DateTime DateTime => DateTime.Parse(Time);
    public string ParsedTime => DateTime.Parse(Time).ToShortTimeString();

    public string Temperature { get; set; }
    public string WeatherIcon { get; set; }
}

public class Astronomy {
    [JsonProperty("sunrise")] public string Sunrise { get; set; }
    [JsonProperty("sunset")] public string Sunset { get; set; }
    [JsonProperty("moonrise")] public string Moonrise { get; set; }
    [JsonProperty("moonset")] public string Moonset { get; set; }
}