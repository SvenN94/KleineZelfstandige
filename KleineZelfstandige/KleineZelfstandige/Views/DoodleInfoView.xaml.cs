using KleineZelfstandige.ViewModel;

namespace KleineZelfstandige.Views;

public partial class DoodleInfoView : ContentPage
{
	public DoodleInfoView(DoodleInfoViewModel vm )
	{
		InitializeComponent();
		BindingContext= vm;
	}
}