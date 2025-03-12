using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymClock.Components.Ribbon
{
    public class RibbonTab : HorizontalStackLayout
    {
        public string Title { get; set; }

        public RibbonTab(string title)
        {
            Title = title;
            BackgroundColor = Colors.Transparent;
        }
    }
}
