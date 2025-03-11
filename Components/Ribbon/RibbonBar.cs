using GymClock.Components.Ribbon;
using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace GymClock.Components.Ribbon
{
    public class RibbonBar : VerticalStackLayout
    { 
        private Dictionary<string, RibbonTab> tabs = new Dictionary<string, RibbonTab>();
        private HorizontalStackLayout tabHeaders = new HorizontalStackLayout();
        private HorizontalStackLayout tabContent = new HorizontalStackLayout();
        
        public RibbonBar()
        {//Menüleiste hier kann man au bissle was machen mit dem design
            Children.Add(tabHeaders);
            Children.Add(tabContent);
            BackgroundColor = Colors.SlateGrey;


        }
        //fügt einen Tab hinzu
        public RibbonTab AddTab(string tabName)
        {
            var tab = new RibbonTab(tabName);
            tabs[tabName] = tab;
            tabContent.Children.Add(tab);

            var tabHeader = new Button { Text = tabName };
            tabHeader.Clicked += (sender, args) => ShowTab(tabName);
            tabHeaders.Children.Add(tabHeader);

            return tab;
        }
        //fügt eine Gruppe hinzu
        public void AddGroup(string tabName, RibbonGroup group)
        {
            if (tabs.TryGetValue(tabName, out var tab))
            {
                tab.Children.Add(group);
            }
        }
        //zeigt mir bei der Menüleiste den Tab an
        private void ShowTab(string tabName)
        {
            foreach (var tab in tabs.Values)
            {
                tab.IsVisible = tab.Title == tabName;
            }
        }
    }
}