using MauiApp2.View;

namespace MauiApp2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
		InitializeComponent();

		//nameof(DetailsPage) == "DetailsPage"
        Routing.RegisterRoute(nameof(MainAccountPage), typeof(MainAccountPage));
        Routing.RegisterRoute(nameof(PlayerPage), typeof(PlayerPage));
        }
    }
}
