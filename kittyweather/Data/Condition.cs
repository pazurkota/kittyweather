using Newtonsoft.Json;

namespace kittyweather.Data; 

public class Condition {
    [JsonProperty("text")] public string ConditionState { get; set; } = null!;
    [JsonProperty("code")] public int ConditionCode { get; set; }
}