﻿using System.Diagnostics;

namespace kittyweather.Pages; 

public partial class SettingsPage : ContentPage {
    public SettingsPage() {
        InitializeComponent();
        
        apiKeyLabel.Text = $"API Key: {Preferences.Get("apiKey", "Not found!")}";
    }
    
    private async void OnEntryCompleted(object sender, EventArgs e) {
        await DisplayAlert("Settings", "Api Key successfully saved!", "OK");
        Preferences.Set("apiKey", $"{((Entry)sender).Text}");
    }
}