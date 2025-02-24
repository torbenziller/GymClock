using Microsoft.Maui.Controls;

namespace GymClock
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PopUp), typeof(PopUp));
        }
    }
}
