using Newtonsoft.Json;

namespace kittyweather.Data; 

public class Location {
    [JsonProperty("name")] public string Name { get; set; } = null!;
    [JsonProperty("country")] public string Country { get; set; } = null!;
}