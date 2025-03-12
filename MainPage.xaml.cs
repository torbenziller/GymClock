using GymClock.Components.Pages;
using GymClock.Components.Ribbon;
using GymClock.Controller;
using Microsoft.Maui.Controls;

namespace GymClock
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            InitializeRibbonBar();
        }

        private void InitializeRibbonBar()
        {
            var tab1 = ribbonBar.AddTab("Start");
            var group1 = new RibbonGroup();
            group1.AddButton(new RibbonButton("Speichern", "save.png", () => {  }));
            ribbonBar.AddGroup("Start", group1);
            

            var tab2 = ribbonBar.AddTab("Account");
            var group2 = new RibbonGroup();
            group2.AddButton(new RibbonButton("Ausloggen", "add_d.png", () => { LogoutButton_Clicked(); }));
            ribbonBar.AddGroup("Account", group2);
        }

        private void LogoutButton_Clicked()
        {
            Preferences.Set("IsLoggedIn", false);
            App.Current.MainPage = new Login(); // Wechselt zurück zur Login-Seite
        }

        private async void PopUpButtonClicked(object sender, EventArgs e)
        {
            //Kümmert sich um das Öffnen des PopUps als wäre es eine Benarichtigung
            await popup.ShowAsync();
        }

        
    }

}
