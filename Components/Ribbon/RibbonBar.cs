using GymClock.Components.Ribbon;
using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace GymClock.Components.Ribbon
{
    public class RibbonBar : VerticalStackLayout
    {
        private Dictionary<string, RibbonTab> tabs = new Dictionary<string, RibbonTab>();
        private HorizontalStackLayout tabHeaders = new HorizontalStackLayout
        {
            BackgroundColor = Colors.Transparent,
            Padding = new Thickness(5),
            Spacing = 5
        };
        private VerticalStackLayout tabContent = new VerticalStackLayout
        {
            Padding = new Thickness(5),
            Spacing = 5
        };

        public RibbonBar()
        {
            // Frame-Struktur mit App-Theme-abhängigen Farben
            var frame = new Frame
            {
                Content = new VerticalStackLayout
                {
                    Children = { tabHeaders, tabContent }
                },
                CornerRadius = 2,
                BackgroundColor = Colors.Transparent,
                Padding = 0,
                HasShadow = false
            };

            // Theme-spezifische Eigenschaften über RequestedThemeChanged setzen
            Application.Current.RequestedThemeChanged += (s, a) => UpdateTheme();

            Children.Add(frame);
            BackgroundColor = Colors.Transparent;

            // Initial Theme anwenden
            UpdateTheme();
        }

        private void UpdateTheme()
        {
            bool isDarkTheme = Application.Current.RequestedTheme == AppTheme.Dark;

            // Frame Border
            if (Children.FirstOrDefault() is Frame frame)
            {
                frame.BorderColor = isDarkTheme ? Colors.DimGray : Colors.LightGray;
            }

            // Tab Content Hintergrundfarbe
            tabContent.BackgroundColor = isDarkTheme ? Color.FromArgb("#1E1E1E") : Colors.White;

            // Tab Headers aktualisieren
            foreach (var child in tabHeaders.Children)
            {
                if (child is Button button)
                {
                    button.TextColor = isDarkTheme ? Colors.LightGray : Colors.Black;
                }
            }
        }

        // Tab hinzufügen
        public RibbonTab AddTab(string tabName)
        {
            var tab = new RibbonTab(tabName)
            {
                IsVisible = tabs.Count == 0 // Nur der erste Tab ist sichtbar
            };
            tabs[tabName] = tab;
            tabContent.Children.Add(tab);

            bool isDarkTheme = Application.Current.RequestedTheme == AppTheme.Dark;

            var tabHeader = new Button
            {
                Text = tabName,
                BackgroundColor = Colors.Transparent,
                TextColor = isDarkTheme ? Colors.LightGray : Colors.Black,
                FontAttributes = FontAttributes.Bold,
                Padding = new Thickness(10),
                CornerRadius = 0,
                BorderColor = Colors.Transparent,
                BorderWidth = 0,
                HeightRequest = 30,
            };

            // Theme-adaptive Visual States
            VisualStateManager.SetVisualStateGroups(tabHeader, new VisualStateGroupList
            {
                new VisualStateGroup
                {
                    Name = "CommonStates",
                    States =
                    {
                        new VisualState
                        {
                            Name = "Normal"
                        },
                        new VisualState
                        {
                            Name = "PointerOver",
                            Setters =
                            {
                                new Setter
                                {
                                    Property = Button.BackgroundColorProperty,
                                    Value = isDarkTheme ? Color.FromArgb("#333333") : Colors.WhiteSmoke
                                }
                            }
                        },
                        new VisualState
                        {
                            Name = "Pressed",
                            Setters =
                            {
                                new Setter
                                {
                                    Property = Button.BackgroundColorProperty,
                                    Value = isDarkTheme ? Color.FromArgb("#444444") : Colors.Gainsboro
                                }
                            }
                        }
                    }
                }
            });

            tabHeader.Clicked += (sender, args) => ShowTab(tabName);
            tabHeaders.Children.Add(tabHeader);

            return tab;
        }

        // Gruppe hinzufügen
        public void AddGroup(string tabName, RibbonGroup group)
        {
            if (tabs.TryGetValue(tabName, out var tab))
            {
                tab.Children.Add(group);
            }
        }

        // Tab anzeigen
        private void ShowTab(string tabName)
        {
            foreach (var tab in tabs.Values)
            {
                tab.IsVisible = tab.Title == tabName;
            }

            bool isDarkTheme = Application.Current.RequestedTheme == AppTheme.Dark;

            // Aktiven Tab visuell markieren
            foreach (var header in tabHeaders.Children)
            {
                if (header is Button button)
                {
                    bool isActive = button.Text == tabName;

                    // Theme-abhängige Textfarben
                    if (isActive)
                    {
                        button.TextColor = isDarkTheme ? Colors.White : Colors.Black;
                        button.FontAttributes = FontAttributes.Bold;
                    }
                    else
                    {
                        button.TextColor = isDarkTheme ? Color.FromArgb("#AAAAAA") : Colors.DimGray;
                        button.FontAttributes = FontAttributes.None;
                    }

                    // Minimale Unterstreichung für aktiven Tab
                    if (isActive)
                    {
                        button.BorderColor = isDarkTheme ? Colors.White : Colors.Black;
                        button.BorderWidth = 0;
                        button.Margin = new Thickness(0, 0, 0, -1);
                    }
                    else
                    {
                        button.BorderColor = Colors.Transparent;
                        button.BorderWidth = 0;
                        button.Margin = new Thickness(0);
                    }
                }
            }
        }
    }
}