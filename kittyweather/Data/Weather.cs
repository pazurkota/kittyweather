namespace kittyweather.Data;

public class Weather {
    public Location Location { get; set; } = null!;
    public Current Current { get; set; } = null!;
    public Alerts Alerts { get; set; } = null!;
    public Forecast Forecast { get; set; } = null!;
}