namespace MauiApp2;

public partial class PlayerPage : ContentPage
{
	public PlayerPage(PlayerViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (btnPlay.Text == "Play")
            btnPlay.Text = "Pause";
        else
            btnPlay.Text = "Play";
    }
}