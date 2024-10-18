
using MauiApp2.Services;
using MauiApp2.View;

namespace MauiApp2.ViewModel;

public partial class MainAccountViewModel : BaseViewModel
{

    Login login;

    AccountInfo accountInfo;

    String Token;

    public ObservableCollection<string> GenresList { get; } = new();

    public ObservableCollection<PlaylistGroup.Item> PlayListGroupItems { get; } = new();

    public ObservableCollection<Playlist.Item> Playlist_item { get; } = new();

    readonly IConnectivity connectivity;

    public MainAccountViewModel(AccountInfo accountInfo, Login login, IConnectivity connectivity)
    {
        this.login = login;
        this.accountInfo = accountInfo;
        this.connectivity = connectivity;
    }

    [ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
    async Task GetLoginAsync()
    {
        if (IsBusy)
            return;

        try
        {
            if (Shell.Current == null)
                return;

            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Internet Issue!",
                        $"Check your internet and try again!", "OK");
                return;
            }
            
            IsBusy = true;
            Token = await login.GetLogin();

            var genres_list = await accountInfo.GetGenres(Token);
            foreach (var gen in genres_list)
                GenresList.Add(gen);

            var plau_lists = await accountInfo.GetFeaturedPlaylist(Token);
            foreach (var item in plau_lists.playlists.items)
                PlayListGroupItems.Add(item);

            var play_list = await accountInfo.GetSinglePlaylist(Token, "3cEYpjA9oz9GiPac4AsH4n");
            foreach (var item in play_list.tracks.items)
                Playlist_item.Add(item);


            await Shell.Current.GoToAsync($"{nameof(MainAccountPage)}", true);

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!",
                $"Unable to Login: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    [RelayCommand]
    async Task GoToMusicPlayerAsync(Playlist.Item item)
    {
        if (item is null)
            return;

        await Shell.Current.GoToAsync($"{nameof(PlayerPage)}", true,
            new Dictionary<string, object>
            {
                {"PlaylistItem",item }
            });
    }
    [RelayCommand]
    async Task GoToLoadPlaylist(PlaylistGroup.Item item)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            if (item is null)
                return;

            Playlist_item.Clear();

            var play_list = await accountInfo.GetPlayList(Token, item.id);

            if (play_list == null)
                return;

            if (play_list.tracks == null)
                return;
            
            foreach (var playlist_item in play_list.tracks.items)
                Playlist_item.Add(playlist_item);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!",
                $"Unable to Login: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }
}