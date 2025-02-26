using GymClock.Controller;
using Microsoft.Maui.Controls;

namespace GymClock
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void PopUpButtonClicked(object sender, EventArgs e)
        {
            //Kümmert sich um das Öffnen des PopUps als wäre es eine Benarichtigung
            await PopUpHandler.OpenPopUpInNewWindow(4);
        }

        
    }

}
