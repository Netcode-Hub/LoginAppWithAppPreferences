namespace LoginApp.Api.Model;

public class User
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string?  Password { get; set; }
}
