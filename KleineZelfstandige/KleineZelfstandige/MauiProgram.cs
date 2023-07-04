using CommunityToolkit.Maui;
using KleineZelfstandige.Repository;
using KleineZelfstandige.Repository.Framework;
using KleineZelfstandige.SqlLite;
using KleineZelfstandige.ViewModel;
using KleineZelfstandige.Views;
using KleineZelfstandige.Views.Klant;
using KleineZelfstandige.Views.Menu;

namespace KleineZelfstandige;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()

            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<KlantRepo>();
        builder.Services.AddSingleton<DoodleRepo>();
        builder.Services.AddSingleton<LoginDb>();
        
        builder.Services.AddTransient<KlantenLijstView>();
        builder.Services.AddTransient<KlantListViewModel>();
        builder.Services.AddTransient<KlantProfielViewModel>();
        builder.Services.AddTransient<KlantProfielView>();

        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<LoginView>();

        builder.Services.AddTransient<HomeView>();
        builder.Services.AddTransient<HomeViewViewModel>();

        builder.Services.AddTransient<DoodleViewModel>();
        builder.Services.AddTransient<DoodleView>();
        builder.Services.AddTransient<DoodleInfoViewModel>();
        builder.Services.AddTransient<DoodleInfoView>();

        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddTransient<SettingsView>();      		

        return builder.Build();
    }
}
