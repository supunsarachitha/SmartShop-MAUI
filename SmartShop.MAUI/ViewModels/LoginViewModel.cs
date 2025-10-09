using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartShop.MAUI.Services;
using System.Threading.Tasks;
using System.Text.Json;

namespace SmartShop.MAUI.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string errorMessage;

        public LoginViewModel(AuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        private async void Login()
        {
            Console.WriteLine("LoginAsyncCommand executed");

            if (IsBusy) return;

            IsBusy = true;
            ErrorMessage = string.Empty;

            try
            {
                // Define a class to represent the data structure
                var result = await _authService.LoginAsync<LoginResponse>(Username, Password);

                if (result != null && result.Success && result.Data != null)
                {
                    // Extract the token
                    string token = result.Data.Token;

                    // Handle successful login logic here
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

        // Define a class to represent the data structure
        public class LoginResponse
        {
            public string Token { get; set; }
        }
    }
}
