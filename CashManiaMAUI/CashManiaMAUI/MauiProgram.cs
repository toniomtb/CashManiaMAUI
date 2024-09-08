using CashManiaMAUI.Pages;
using CashManiaMAUI.ViewModels;
using Microsoft.Extensions.Logging;

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

            string localBaseAddress =
                DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7221" : "https://localhost:7221";
            string remoteBaseAddress = "https://192.168.1.10:7221";
            builder.Services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri(remoteBaseAddress) });

            //view models
            builder.Services.AddTransient<SignUpPageViewModel>();

            //pages
            builder.Services.AddTransient<SignUpPage>();

            return builder.Build();
        }
    }
}
