using SmartShop.MAUI.ViewModels;

namespace SmartShop.MAUI.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel();

    }
}