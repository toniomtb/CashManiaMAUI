using CashManiaMAUI.Pages;
using CashManiaMAUI.Services.Interfaces;

namespace CashManiaMAUI
{
    public partial class App : Application
    {
        private readonly ISecureStorageService _secureStorageService;
        private readonly IApiService _apiService;

        public App(ISecureStorageService secureStorageService, IApiService apiService)
        {
            InitializeComponent();

            _secureStorageService = secureStorageService;
            _apiService = apiService;

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            base.OnStart();

            var loginToken = await _secureStorageService.GetLoginTokenAsync();

            if (!string.IsNullOrEmpty(loginToken) && await IsTokenValid(loginToken))
                await Shell.Current.GoToAsync("//" + nameof(HomePage));
        }

        protected override async void OnResume()
        {
            base.OnResume();

            var loginToken = await _secureStorageService.GetLoginTokenAsync();

            if (string.IsNullOrEmpty(loginToken) || !await IsTokenValid(loginToken))
                await Shell.Current.GoToAsync(nameof(SignInPage));
        }

        private async Task<bool> IsTokenValid(string token)
        {
            return await _apiService.CheckLoginTokenIsValid(token);
        }

    }
}
