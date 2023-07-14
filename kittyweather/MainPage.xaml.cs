namespace kittyweather;

public partial class MainPage : ContentPage {
    private readonly Random _random = new Random();

    public MainPage() {
        InitializeComponent();
    }

    private void RefreshTemperature(object sender, EventArgs e) {
        int temp = _random.Next(-20, 40);
        string text = "Current temperature = " + temp + "°C";

        TemperatureText.Text = text;
    }
}