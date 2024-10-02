namespace MauiApp2.View;

public partial class MainAccountPage : ContentPage
{
	public MainAccountPage(UsersViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}