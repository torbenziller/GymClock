using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymClock.Controller
{
    public static class PopUpHandler
    {
        public static async Task OpenPopUpInNewWindow(int delay)
        {
            var popUpPage = new PopUp();
            var window = new Window(popUpPage)
            {
                Width = 884,
                Height = 430
            };

            var displayInfo = DeviceDisplay.MainDisplayInfo;
            var density = displayInfo.Density;

            // Berechne die Position unten rechts
            window.X = (displayInfo.Width / density) - window.Width;
            window.Y = (displayInfo.Height / density) - window.Height;

            Application.Current.OpenWindow(window);

            // Berechne den Verzögerungswert in Millisekunden
            int closeDelay = delay * 1000;

            // Schließe das Fenster nach der angegebenen Verzögerung
            await Task.Delay(closeDelay);
            Application.Current.CloseWindow(window);
        }
    }
}
