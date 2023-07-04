using KleineZelfstandige.ViewModel;

namespace KleineZelfstandige.Views;

public partial class DoodleView : ContentPage
{
	public DoodleView(DoodleViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}