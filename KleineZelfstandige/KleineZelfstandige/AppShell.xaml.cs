using KleineZelfstandige.Views;
using KleineZelfstandige.Views.Klant;
using KleineZelfstandige.Views.Menu;

namespace KleineZelfstandige;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(KlantProfielView),typeof(KlantProfielView));
        Routing.RegisterRoute(nameof(KlantenLijstView),typeof(KlantenLijstView));
        Routing.RegisterRoute(nameof(HomeView),typeof(HomeView));
        Routing.RegisterRoute(nameof(LoginView),typeof(LoginView));
        Routing.RegisterRoute(nameof(DoodleInfoView),typeof(DoodleInfoView));
        Routing.RegisterRoute(nameof(DoodleView),typeof(DoodleView));
        Routing.RegisterRoute(nameof(SettingsView),typeof(SettingsView));        
    }
}
