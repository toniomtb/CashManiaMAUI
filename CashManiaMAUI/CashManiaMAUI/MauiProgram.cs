﻿using CashManiaMAUI.Automapper;
using CashManiaMAUI.Pages;
using CashManiaMAUI.Services;
using CashManiaMAUI.Services.Interfaces;
using CashManiaMAUI.ViewModels;

namespace CashManiaMAUI
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

            // Automapper
            builder.Services.AddAutoMapper(typeof(DTOToDomainMappingPorfile), 
                                           typeof(DomainToDTOMappingProfile));

            string localBaseAddress =
                DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5240" : "http://localhost:5240";
            string remoteBaseAddress = "http://192.168.1.2:5240";
            builder.Services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri(remoteBaseAddress) });

            // Services
            builder.Services.AddScoped<IApiService, ApiService>();
            builder.Services.AddSingleton<ISecureStorageService, SecureStorageService>();
            builder.Services.AddScoped<ICashManiaApiService, CashManiaApiService>();

            // View Models
            builder.Services.AddTransient<SignUpPageViewModel>();
            builder.Services.AddTransient<SignInPageViewModel>();

            // Pages
            builder.Services.AddTransient<SignUpPage>();
            builder.Services.AddTransient<LoginPage>();

            return builder.Build();
        }
    }
}
