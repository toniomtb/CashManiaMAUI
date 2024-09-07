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

            //view models
            builder.Services.AddTransient<SignUpPageViewModel>();

            //pages
            builder.Services.AddTransient<SignUpPage>();

            return builder.Build();
        }
    }
}
