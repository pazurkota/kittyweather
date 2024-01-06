using kittyweather.Data;

namespace kittyweather.Pages;

public partial class WelcomePage : ContentPage
{
    public WelcomePage()
    {
        InitializeComponent();
    }

    async void SetApiKey_OnClicked(object sender, EventArgs e)
    {
        string apiKey = ((Entry)sender).Text;
        bool isValid = await ApiService.CheckApiKey(apiKey);
        
        if (isValid)
        {
            Preferences.Set("apiKey", apiKey);
            await DisplayAlert("Info", "API Key successfully saved!", "OK");

            await Navigation.PushModalAsync(new AppShell { FlyoutBehavior = FlyoutBehavior.Disabled });
        }
        else
        {
            await DisplayAlert("Error", "API Key is invalid!", "OK");
        }
    }
}

