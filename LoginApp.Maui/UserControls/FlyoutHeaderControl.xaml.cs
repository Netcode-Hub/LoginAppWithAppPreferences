namespace LoginApp.Maui.UserControls;

public partial class FlyoutHeaderControl : ContentView
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();
		if(App.user != null)
		{
			lblUserName.Text = "Logged in as: " + App.user.Email;
			lblUserEmail.Text = App.user.Email;
		}
	}
}