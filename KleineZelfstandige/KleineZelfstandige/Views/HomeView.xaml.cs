using KleineZelfstandige.ViewModel;

namespace KleineZelfstandige.Views;

public partial class HomeView : ContentPage
{
    public HomeView(HomeViewViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

}