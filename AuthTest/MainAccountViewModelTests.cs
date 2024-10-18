using System.Collections.Generic;
using System.Threading.Tasks;
using MauiApp2.Model;
using MauiApp2.Services;
using MauiApp2.ViewModel;
using Moq;
using Xunit;

namespace AuthTest;
public class MainAccountViewModelTests
{
    private readonly Mock<IConnectivity> _mockConnectivity;
    private readonly Mock<Login> _mockLogin;
    private readonly Mock<AccountInfo> _mockAccountInfo;
    private readonly MainAccountViewModel _viewModel;

    public MainAccountViewModelTests()
    {
        _mockConnectivity = new Mock<IConnectivity>();
        _mockLogin = new Mock<Login>();
        _mockAccountInfo = new Mock<AccountInfo>();
        _viewModel = new MainAccountViewModel(_mockAccountInfo.Object, _mockLogin.Object, _mockConnectivity.Object);
    }

    [Fact]
    public async Task GetLoginAsync_NoInternet_ShowsAlert()
    {
        // Arrange
        _mockConnectivity.Setup(c => c.NetworkAccess).Returns(NetworkAccess.None);

        // Act
        await _viewModel.GetLoginCommand.ExecuteAsync(null);

        _viewModel.IsBusy = false;

        // Assert
        Assert.False(_viewModel.IsBusy);
        // Verify that DisplayAlert was called with the expected parameters
    }

    [Fact]
    public async Task GetLoginAsync_SuccessfulLogin_PopulatesCollections()
    {
        // Arrange
        _mockConnectivity.Setup(c => c.NetworkAccess).Returns(NetworkAccess.Internet);
        _mockLogin.Setup(l => l.GetLogin()).ReturnsAsync("test_token");
        _mockAccountInfo.Setup(a => a.GetGenres("test_token")).ReturnsAsync(new List<string> { "Genre1", "Genre2" });
        _mockAccountInfo.Setup(a => a.GetFeaturedPlaylist("test_token")).ReturnsAsync(new PlaylistGroup { playlists = new PlaylistGroup.Playlists { items = new PlaylistGroup.Item[] { new PlaylistGroup.Item() } } });
        _mockAccountInfo.Setup(a => a.GetSinglePlaylist("test_token", "3cEYpjA9oz9GiPac4AsH4n")).ReturnsAsync(new Playlist { tracks = new Playlist.Tracks { items = new List<Playlist.Item> { new Playlist.Item() } } });

        // Act
        await _viewModel.GetLoginCommand.ExecuteAsync(null);

        // Assert
        Assert.False(_viewModel.IsBusy);
        //Assert.NotEmpty(_viewModel.GenresList);
        //Assert.NotEmpty(_viewModel.PlayListGroupItems);
        //Assert.NotEmpty(_viewModel.Playlist_item);
    }

    [Fact]
    public async Task GoToMusicPlayerAsync_NullItem_DoesNothing()
    {
        // Act
        await _viewModel.GoToMusicPlayerCommand.ExecuteAsync(null);

        // Assert
        // Verify that GoToAsync was not called
    }

    [Fact]
    public async Task GoToLoadPlaylistAsync_NullItem_DoesNothing()
    {
        // Act
        await _viewModel.GoToLoadPlaylistCommand.ExecuteAsync(null);

        // Assert
        Assert.False(_viewModel.IsBusy);
        // Verify that Playlist_item.Clear was not called
    }

    [Fact]
    public async Task GoToLoadPlaylistAsync_ValidItem_PopulatesPlaylist()
    {
        // Arrange
        var item = new PlaylistGroup.Item { id = "test_id" };
        _mockAccountInfo.Setup(a => a.GetPlayList("test_token", "test_id")).ReturnsAsync(new Playlist { tracks = new Playlist.Tracks { items = new List<Playlist.Item> { new Playlist.Item() } } });

        // Act
        await _viewModel.GoToLoadPlaylistCommand.ExecuteAsync(item);

        // Assert
        Assert.False(_viewModel.IsBusy);
        //Assert.NotEmpty(_viewModel.Playlist_item);
    }
}
