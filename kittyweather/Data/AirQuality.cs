using Newtonsoft.Json;

namespace kittyweather.Data; 

public class AirQuality {
    [JsonProperty("co")] public decimal Co { get; set; }
    [JsonProperty("o3")] public decimal O3 { get; set; }
    [JsonProperty("no2")] public decimal No2 { get; set; }
    [JsonProperty("so2")] public decimal So2 { get; set; }
    [JsonProperty("pm2_5")] public decimal Pm25 { get; set; }
    [JsonProperty("pm10")] public decimal Pm10 { get; set; }
    [JsonProperty("us-epa-index")] public int UsEpaIndex { get; set; }
}