namespace GymClock.Components.Pages;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent();
	}

    public async void SettingUserOverview(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserOverview());
    }
}