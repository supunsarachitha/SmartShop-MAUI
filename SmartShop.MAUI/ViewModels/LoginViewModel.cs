using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartShop.MAUI.Models.Responses;
using SmartShop.MAUI.Services;

namespace SmartShop.MAUI.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        public LoginViewModel(AuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        private async Task Login()
        {
            Console.WriteLine("Login executed");

            if (IsBusy) return;

            IsBusy = true;
            ErrorMessage = string.Empty;

            try
            {
                var result = await _authService.LoginAsync<LoginResponse>(Username, Password);

                if (result != null && result.Success && result.Data != null)
                {
                    // Extract the token
                    string token = result.Data.Token;

                    Console.WriteLine($"Token: {token}");
                }
                else
                {
                    ErrorMessage = result?.Message ?? "Invalid username or password.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Login failed: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private void ForgotPassword()
        {
            // Implement forgot password logic
        }
         

    }
}
