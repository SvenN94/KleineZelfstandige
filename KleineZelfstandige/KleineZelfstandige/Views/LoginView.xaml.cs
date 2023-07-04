using KleineZelfstandige.ViewModel;

namespace KleineZelfstandige.Views;

public partial class LoginView : ContentPage
{
    public LoginView(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext= vm;
    }
}