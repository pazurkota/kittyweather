﻿using kittyweather.Pages;
using kittyweather.ViewModel;
using Microsoft.Extensions.Logging;

namespace kittyweather;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<WeatherPage>();
        builder.Services.AddSingleton<WeatherViewModel>();

        return builder.Build();
    }
}