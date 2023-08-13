﻿using System.Diagnostics;

namespace kittyweather.Pages; 

public partial class SettingsPage : ContentPage {
    public SettingsPage() {
        InitializeComponent();
    }
    
    private async void OnEntryCompleted(object sender, EventArgs e) {
        await DisplayAlert("Info", "API Key successfully saved!", "OK");
        Preferences.Set("apiKey", $"{((Entry)sender).Text}");
    }

    private async void RevealApiKey(object sender, EventArgs e) {
        var apiKey = Preferences.Get("apiKey", null);

        if (apiKey != null) {
            ApiKeyLabel.Text = apiKey;
            ApiKeyLabel.IsVisible = true;
        }
        else {
            await DisplayAlert("Error", "Cannot reveal API Key: key is not set!", "OK");
            ApiKeyLabel.IsVisible = false;
        }
    }

    private async void CopyApiKey(object sender, EventArgs e) {
        var apiKey = Preferences.Get("apiKey", null);

        if (apiKey != null) {
            await Clipboard.Default.SetTextAsync(apiKey);
        }
        else {
            await DisplayAlert("Error", "Cannot copy API Key: key is not set!", "OK");
        }
    }
}