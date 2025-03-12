using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using static Microsoft.Maui.Controls.Button;
using static Microsoft.Maui.Controls.Button.ButtonContentLayout;

namespace GymClock.Components.Ribbon
{
    public class RibbonButton : VerticalStackLayout
    {
        public RibbonButton(string text, string iconSource, System.Action onClicked)
        {
            // Erstellen eines Buttons
            var button = new Button
            {
                FontSize = 14,
                HeightRequest = 60, // Erhöhen Sie die Höhe, um Platz für das Icon zu schaffen
                WidthRequest = 60,  // Erhöhen Sie die Breite, um Platz für das Icon zu schaffen
                BackgroundColor = Colors.Blue,
                ContentLayout = new ButtonContentLayout(ButtonContentLayout.ImagePosition.Top, 10) // Icon oben, Text unten
            };
            button.Clicked += (sender, args) => onClicked?.Invoke();

            // Image anpassen in der Größe
            var imageView = new Image
            {
                Source = ImageSource.FromFile(iconSource),
                WidthRequest = 32,
                HeightRequest = 32,
                Aspect = Aspect.AspectFit
            };

            // Label für den Text
            var label = new Label
            {
                Text = text,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End,
                FontSize = 12,
                TextColor = Colors.Black
            };

            // Grid Layout für Button und Image
            var grid = new Grid
            {
                HeightRequest = 60,
                WidthRequest = 60
            };
            grid.Children.Add(imageView);
            grid.Children.Add(label);

            // Layout anpassen
            var layout = new VerticalStackLayout
            {
                Children = { grid },
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 5
            };

            // Hier fügen wir das Layout zu den Kindern hinzu also die Elemente, die in diesem StackLayout chillen
            Children.Add(layout);
            Children.Add(button);
        }
    }
}