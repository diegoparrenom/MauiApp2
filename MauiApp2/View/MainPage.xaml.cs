namespace MauiApp2.View;

public partial class MainPage : ContentPage
{
	public MainPage(MainAccountViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}

