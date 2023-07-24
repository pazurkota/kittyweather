using System.Diagnostics;

namespace kittyweather.Pages; 

public partial class SettingsPage : ContentPage {
    public SettingsPage() {
        InitializeComponent();
    }
    
    private async void OnEntryCompleted(object sender, EventArgs e) {
        await DisplayAlert("Settings", "Api Key successfully saved!", "OK");
        apiKeyLabel.Text = $"API Key: {((Entry)sender).Text}";
        
        Preferences.Set("apikey", $"{((Entry)sender).Text}");
    }
}