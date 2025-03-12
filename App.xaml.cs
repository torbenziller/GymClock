using GymClock.Components.Pages;

namespace GymClock
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            bool isLoggedIn = Preferences.Get("IsLoggedIn", false);

            if (isLoggedIn)
                MainPage = new AppShell();  // Lädt die Shell mit TabBar
            else
                MainPage = new Login(); // Zeigt die Login-Seite zuerst an
        }
    }
}
