namespace MauiApp2.ViewModel;

[QueryProperty("Item", "PlaylistItem")]
public partial class PlayerViewModel : BaseViewModel
{
	public PlayerViewModel()
	{

	}

    [ObservableProperty]
    Playlist.Item item;
}