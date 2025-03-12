using GymClock.Components.Ribbon;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace GymClock.Components.Ribbon
{
    public class RibbonBar : VerticalStackLayout
    {
        private Dictionary<string, RibbonTab> tabs = new Dictionary<string, RibbonTab>();
        private HorizontalStackLayout tabHeaders = new HorizontalStackLayout
        {
            BackgroundColor = Colors.LightGray,
            Padding = new Thickness(5),
            Spacing = 5
        };
        private VerticalStackLayout tabContent = new VerticalStackLayout
        {
            BackgroundColor = Colors.Black,
            Padding = new Thickness(5),
            Spacing = 5
        };

        public RibbonBar()
        {
            // Menüleiste hier kann man au bissle was machen mit dem design
            var frame = new Frame
            {
                Content = new VerticalStackLayout
                {
                    Children = { tabHeaders, tabContent }
                },
                CornerRadius = 10, // Ecken abrunden
                BackgroundColor = Colors.Transparent,
                BorderColor = Colors.LightGray,
                Padding = 0,
                HasShadow = false
            };

            Children.Add(frame);
            BackgroundColor = Colors.Transparent;
        }

        // fügt einen Tab hinzu
        public RibbonTab AddTab(string tabName)
        {
            var tab = new RibbonTab(tabName)
            {
                IsVisible = tabs.Count == 0 // Nur der erste Tab ist sichtbar
            };
            tabs[tabName] = tab;
            tabContent.Children.Add(tab);

            var tabHeader = new Button
            {
                Text = tabName,
                BackgroundColor = Colors.Transparent,
                TextColor = Colors.Black,
                FontAttributes = FontAttributes.Bold,
                Padding = new Thickness(10),
                CornerRadius = 5,
                BorderColor = Colors.Transparent,
                BorderWidth = 1,
                HeightRequest = 2,
            };

            // VisualStateManager für Hover-Effekt
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
                                        Value = Colors.LightBlue
                                    },
                                    new Setter
                                    {
                                        Property = Button.BorderColorProperty,
                                        Value = Colors.Blue
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
                                        Value = Colors.DarkBlue
                                    },
                                    new Setter
                                    {
                                        Property = Button.TextColorProperty,
                                        Value = Colors.White
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

        // fügt eine Gruppe hinzu
        public void AddGroup(string tabName, RibbonGroup group)
        {
            if (tabs.TryGetValue(tabName, out var tab))
            {
                tab.Children.Add(group);
            }
        }

        // zeigt mir bei der Menüleiste den Tab an
        private void ShowTab(string tabName)
        {
            foreach (var tab in tabs.Values)
            {
                tab.IsVisible = tab.Title == tabName;
            }
        }
    }
}