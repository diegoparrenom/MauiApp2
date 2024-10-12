namespace AuthTest
{
    public class UnitTest1
    {
        string resultToken;

        MauiApp2.Services.Login LoginTest;
        MauiApp2.Services.AccountInfo AccountTest;

        public UnitTest1()
        {
            LoginTest = new MauiApp2.Services.Login();
            AccountTest = new MauiApp2.Services.AccountInfo();
            resultToken = "";
        }

        [Fact]
        public async Task Test1_Login()
        {
            resultToken = await LoginTest.GetLogin();
            Assert.IsType<string>(resultToken);
        }
        [Fact]
        public async Task Test2_TokenLength()
        {
            resultToken = await LoginTest.GetLogin();
            Assert.InRange(resultToken.Length, 5, 200);
        }
        [Fact]
        public async Task TestGenresNumber()
        {
            resultToken = await LoginTest.GetLogin();

            var genres_list = await AccountTest.GetGenres(resultToken);
            Assert.InRange(genres_list.Count, 5, 200);
        }
        [Fact]
        public async Task TestIsFeaturedPlaylist()
        {
            resultToken = await LoginTest.GetLogin();

            var FeatPlaylist = await AccountTest.GetFeaturedPlaylist(resultToken);
            Assert.IsType<MauiApp2.Model.PlaylistGroup>(FeatPlaylist);

        }
        [Fact]
        public async Task TestGetFeaturedPlaylistNumber()
        {
            resultToken = await LoginTest.GetLogin();

            var FeatPlaylist = await AccountTest.GetFeaturedPlaylist(resultToken);
            Assert.InRange(FeatPlaylist.playlists.items.Length, 5, 200);

        }
        [Fact]
        public async Task TestIsSinglePlaylist()
        {
            resultToken = await LoginTest.GetLogin();

            var SinglePlaylist = await AccountTest.GetSinglePlaylist(resultToken, "3cEYpjA9oz9GiPac4AsH4n");
            Assert.IsType<MauiApp2.Model.Playlist>(SinglePlaylist);
        }
        [Fact]
        public async Task TestGetSinglePlaylistNumber()
        {
            resultToken = await LoginTest.GetLogin();

            var SinglePlaylist = await AccountTest.GetSinglePlaylist(resultToken, "3cEYpjA9oz9GiPac4AsH4n");
            Assert.InRange(SinglePlaylist.tracks.items.Count, 5, 200);
        }
        [Fact]
        public async Task TestIsPlayList()
        {
            resultToken = await LoginTest.GetLogin();

            var FeatPlaylist = await AccountTest.GetFeaturedPlaylist(resultToken);

            var Playlist_id = FeatPlaylist.playlists.items.First().id;

            var result_playlist = await AccountTest.getPlayList(resultToken, Playlist_id);

            Assert.IsType<MauiApp2.Model.Playlist>(result_playlist);

        }
        [Fact]
        public async Task TestGetPlayListNumber()
        {
            resultToken = await LoginTest.GetLogin();

            var FeatPlaylist = await AccountTest.GetFeaturedPlaylist(resultToken);

            var Playlist_id = FeatPlaylist.playlists.items.First().id;

            var result_playlist = await AccountTest.getPlayList(resultToken, Playlist_id);

            Assert.InRange(result_playlist.tracks.items.Count, 5, 200);

        }

    }
}