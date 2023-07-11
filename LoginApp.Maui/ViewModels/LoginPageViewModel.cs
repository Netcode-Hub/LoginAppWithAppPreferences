using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginApp.Maui.Services;
using LoginApp.Maui.Models;
using System.Text.Json.Serialization;
using LoginApp.Maui.Views;
using Newtonsoft.Json;
using LoginApp.Maui.UserControls;

namespace LoginApp.Maui.ViewModels;

public partial class LoginPageViewModel : ObservableObject
{
    [ObservableProperty]
    private string _userName;

    [ObservableProperty]
    private string _password;

    readonly ILoginService loginService = new LoginService();

    [RelayCommand]
    public async void Login()
    {
        try
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password))
                {
                    User user = await loginService.Login(UserName, Password);
                    if (user == null)
                    {
                        await Shell.Current.DisplayAlert("Error", "Username/Password is incorrect", "Ok");
                        return;
                    }
                    if (Preferences.ContainsKey(nameof(App.user)))
                    {
                        Preferences.Remove(nameof(App.user));
                    }
                    string userDetails = JsonConvert.SerializeObject(user);
                    Preferences.Set(nameof(App.user), userDetails);
                    App.user = user;
                    AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
                    await Shell.Current.GoToAsync(nameof(HomePage));
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "All fields required", "Ok");
                    return;
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "No Internet Access", "Ok");
                return;
            }

        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            return;
        }


    }
}
