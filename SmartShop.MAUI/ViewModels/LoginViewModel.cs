using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartShop.MAUI.Models.Responses;
using SmartShop.MAUI.Services;
using System.Windows.Input;

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
        private string alertMessage = string.Empty;

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
            AlertMessage = string.Empty;

            try
            {
                var result = await _authService.LoginAsync<LoginResponse>(Username, Password);

                if (result != null && result.Success && result.Data != null)
                {
                    // Extract the token
                    string token = result.Data.Token;

                    Console.WriteLine($"Token: {token}");

                    // Navigate to HomePage.xaml
                    await Shell.Current.GoToAsync("//HomePage");


                    //Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
                }
                else
                {
                    AlertMessage = result?.Message ?? "Invalid username or password.";
                }
            }
            catch (Exception ex)
            {
                AlertMessage = $"Login failed: {ex.Message}";
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
