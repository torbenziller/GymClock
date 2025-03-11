using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using static Microsoft.Maui.Controls.Button.ButtonContentLayout;

namespace GymClock.Components.Ribbon
{
    public class RibbonButton : VerticalStackLayout
    {
        public RibbonButton(string text, string iconSource, System.Action onClicked)
        {
            // Erstellet einen Button
            var button = new Button
            {
                Text = text,
                FontSize = 14,
                
            };
            button.Clicked += (sender, args) => onClicked?.Invoke();

            // Image anpassen in der größe
            var imageView = new Image
            {
                Source = ImageSource.FromFile(iconSource),
                WidthRequest = 32,
                HeightRequest = 32,
                Aspect = Aspect.AspectFit
            };

            // Layout anpassen
            var layout = new VerticalStackLayout
            {
                Children = { imageView, new Label { Text = text, HorizontalOptions = LayoutOptions.Center } },
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 5
            };

            // Hier fügen wir das Layout zu den Kindern hinzu also die Elemente, die in diesem StackLayout chillen
            Children.Add(layout);
            Children.Add(button);
        }
    }
}