using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using static Microsoft.Maui.Controls.Button;


namespace GymClock.Components.Ribbon
{
    public class RibbonButton : VerticalStackLayout
    {
        public RibbonButton(string text, string iconSource, System.Action onClicked)
        {
            // Grid Layout für Icon und Button
            var grid = new Grid
            {
                HeightRequest = 60,
                WidthRequest = 60
            };

            // Image anpassen in der Größe
            var imageView = new Image
            {
                Source = ImageSource.FromFile(iconSource),
                WidthRequest = 50,
                HeightRequest = 50,
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            // Button erstellen (transparent mit milchigem Hintergrund)
            var button = new Button
            {
                BackgroundColor = Color.FromArgb("#80FFFFFF"), // Milchiger Hintergrund (50% Transparenz)
                BorderColor = Colors.Transparent,
                BorderWidth = 0,
                HeightRequest = 60,
                WidthRequest = 60,
                CornerRadius = 10 // Abgerundete Ecken
            };
            button.Clicked += (sender, args) => onClicked?.Invoke();

            // Hover-Effekt
            VisualStateManager.SetVisualStateGroups(button, new VisualStateGroupList()
            {
                new VisualStateGroup()
                {
                    Name = "CommonStates",
                    States =
                    {
                        new VisualState()
                        {
                            Name = "Normal"
                        },
                        new VisualState()
                        {
                            Name = "PointerOver",
                            Setters =
                            {
                                new Setter() { Property = Button.BackgroundColorProperty, Value = Color.FromArgb("#C0FFFFFF") } // Hellerer Hintergrund bei Hover
                            }
                        }
                    }
                }
            });

            // Grid hinzufügen und Elemente hinzufügen
            grid.Children.Add(imageView);
            grid.Children.Add(button); // Button über dem Icon

            // Label für den Button-Namen
            var label = new Label
            {
                Text = text,
                FontSize = 12,
                HorizontalOptions = LayoutOptions.Center
            };

            // Layout anpassen
            Children.Add(grid);
            Children.Add(label); // Label unter dem Grid hinzufügen
        }
    }
}