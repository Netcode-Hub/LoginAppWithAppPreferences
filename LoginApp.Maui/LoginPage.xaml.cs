using LoginApp.Maui.ViewModels;

namespace LoginApp.Maui;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
        BindingContext = loginPageViewModel;
    }
}