using KleineZelfstandige.ViewModel;

namespace KleineZelfstandige.Views.Klant;

public partial class KlantenLijstView : ContentPage
{
    public KlantenLijstView(KlantListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    
}