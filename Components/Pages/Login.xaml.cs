using GymClock.Controller;

namespace GymClock.Components.Pages;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();

    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        bool success = await CheckLoginAsync(username, password);

        if (success)
        {
            Preferences.Set("IsLoggedIn", true); // Speichert den Login-Status

            // Stelle sicher, dass die Shell geladen wird, damit die TabBar angezeigt wird!
            App.Current.MainPage = new AppShell();
        }
        else
        {
            ErrorLabel.Text = "Falsche Zugangsdaten!";
            ErrorLabel.IsVisible = true;
        }
    }

    private Task<bool> CheckLoginAsync(string username, string password)
    {
        // Hier deine Logik: Prüfung gegen DB, REST-API, Mock etc.
        // Zum Testen einfach:
        return Task.FromResult(username == "tz" && password == " ");
    }



}