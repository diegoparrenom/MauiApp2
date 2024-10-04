namespace MauiApp2.View;

public partial class MainAccountPage : ContentPage
{
	public MainAccountPage(MainAccountViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}