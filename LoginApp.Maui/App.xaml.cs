namespace LoginApp.Maui;
using LoginApp.Maui.Models;
public partial class App : Application
{
    public static User user;
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}