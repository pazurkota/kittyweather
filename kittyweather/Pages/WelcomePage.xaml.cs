using kittyweather.Data;
namespace kittyweather.Pages; 

public partial class WelcomePage : ContentPage {
    public WelcomePage() {
        InitializeComponent();
    }

    private async void ApiKeyEntry(object sender, EventArgs e)
    {
        var apiKey = (sender as Entry)?.Text;
        await ApiService.CheckApiKey(apiKey);

        Preferences.Set("apiKey", apiKey);
    }
}