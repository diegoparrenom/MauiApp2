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
        //solo para Test //quitar el virtual al ejectuar el proyecto
        virtual public async Task<List<string>> GetGenres(string token)
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
        //solo para Test //quitar el virtual al ejectuar el proyecto
        virtual public async Task<PlaylistGroup> GetFeaturedPlaylist(string token)
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
        //solo para Test //quitar el virtual al ejectuar el proyecto
        virtual public async Task<Playlist> GetSinglePlaylist(string token,string userId)
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
        //solo para Test //quitar el virtual al ejectuar el proyecto
        virtual public async Task<Playlist> GetPlayList(string token, string playListId)
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

    }
}
