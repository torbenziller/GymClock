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
            await Shell.Current.GoToAsync(nameof(PopUp), true);
        }
    }

}
