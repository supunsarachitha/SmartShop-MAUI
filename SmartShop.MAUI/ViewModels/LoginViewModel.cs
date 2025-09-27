using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace SmartShop.MAUI.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string errorMessage;

        [RelayCommand]
        private async Task LoginAsync()
        {
            IsBusy = true;
            ErrorMessage = string.Empty;
            await Task.Delay(1000); // Simulate login process
            if (Username == "admin" && Password == "password")
            {
                // Successful login logic here
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
            }
            IsBusy = false;
        }

        [RelayCommand]
        private void ForgotPassword()
        {
            // Implement forgot password logic
        }
    }
}
