﻿using Microsoft.Extensions.Logging;
using MauiApp2.Services;
using MauiApp2.View;

namespace MauiApp2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<IMap>(Map.Default);

        builder.Services.AddSingleton<Login>();
        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<AccountInfo>(); 


        builder.Services.AddSingleton<UsersViewModel>();
		builder.Services.AddTransient<UserDetailsViewModel>();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddTransient<MainAccountPage>();
            

            return builder.Build();
        }
    }
}
