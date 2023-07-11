using LoginApp.Maui.Models;

namespace LoginApp.Maui.Services;

public interface ILoginService
{
    Task<User> Login(string email, string password);
}
