using Newtonsoft.Json;

namespace kittyweather.Data; 

public class Location {
    [JsonProperty("name")] public string Name { get; set; } = "- -";
    [JsonProperty("country")] public string Country { get; set; } = null!;
    [JsonProperty("localtime")] public string LocalTime { get; set; } = null!;
    public DateTime LocalTimeParsed => DateTime.Parse(LocalTime);
}