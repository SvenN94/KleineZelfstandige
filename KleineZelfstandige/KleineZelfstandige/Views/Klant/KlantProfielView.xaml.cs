using KleineZelfstandige.ViewModel;

namespace KleineZelfstandige.Views.Klant;

public partial class KlantProfielView : ContentPage
{
    public KlantProfielView(KlantProfielViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}