using KleineZelfstandige.ViewModel;

namespace KleineZelfstandige.Views.Menu;

public partial class SettingsView : ContentPage
{
	public SettingsView(SettingsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}