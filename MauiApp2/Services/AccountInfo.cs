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
    }
}
