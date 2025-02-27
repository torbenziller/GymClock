using GymClock.Controller;

namespace GymClock;

public partial class NPopUp : ContentView
{
    public NPopUp()
    {
        InitializeComponent();
    }
    public async Task ShowAsync()
    {
        popupView.IsVisible = true;
        await popupView.FadeTo(1.0, 500);
        await Task.Delay(10000); // Anzeigezeit der Benachrichtigung
        await popupView.FadeTo(0.0, 500);
        popupView.IsVisible = false;
    }

    private async void OnDetailsButtonClicked(object sender, EventArgs e)
    {
        // PopUp-Seite anzeigen
        await PopUpHandler.OpenPopUpInNewWindow(4, false);
    }
}
