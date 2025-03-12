using GymClock.Components.Ribbon;
using Microsoft.Maui.Controls;

namespace GymClock.Components.Ribbon
{
    public class RibbonGroup : HorizontalStackLayout
    {
        public RibbonGroup()
        {
            Spacing = 20;
            Padding = new Thickness(10);
            BackgroundColor = Colors.Transparent;
            // das hier ist eine trennlinie zwischen den Gruppen hab ich jetzt mal so gemacht
            Children.Add(new BoxView { HeightRequest = 20, BackgroundColor = Colors.Pink });
        }

        public void AddButton(RibbonButton button)
        {
            Children.Add(button);
        }
    }
}