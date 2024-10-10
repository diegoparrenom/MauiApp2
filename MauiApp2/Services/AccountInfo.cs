using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static MauiApp2.Services.Login;

namespace MauiApp2.Services
{
    public class AccountInfo
    {
        HttpClient httpClient;

        Genres genres;

        List<string> genresList = new();

        PlaylistGroup playlist_group = new();

        Playlist playlist=new();    

        public AccountInfo()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<string>> GetGenres(string token)
        {
            var url = "https://api.spotify.com/v1/recommendations/available-genre-seeds";

            httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                genres = await response.Content.ReadFromJsonAsync<Genres>();
                genresList = genres.genres.OfType<string>().ToList(); ;
            }

            return genresList;
        }
        public async Task<PlaylistGroup> GetFeaturedPlaylist(string token)
        {
            var url = "https://api.spotify.com/v1/browse/featured-playlists";

            httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                playlist_group = await response.Content.ReadFromJsonAsync<PlaylistGroup>();

            }
            return playlist_group;
        }

        public async Task<Playlist> GetSinglePlaylist(string token,string userId)
        {
            var url = "https://api.spotify.com/v1/playlists/"+userId;

            httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                playlist = await response.Content.ReadFromJsonAsync<Playlist>();

            }
            return playlist;
        }

        public async Task<Playlist> getPlayList(string token, string playListId)
        {
            var url = "https://api.spotify.com/v1/playlists/" + playListId;

            httpClient.DefaultRequestHeaders.Authorization =
                           new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                playlist = await response.Content.ReadFromJsonAsync<Playlist>();

            }

            return playlist;
        }

        public static string testfunction()
        {
            return "skdñfj";
        }
    }
}
