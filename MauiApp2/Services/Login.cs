using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace MauiApp2.Services;

public class Login
{
    HttpClient httpClient;

    string Token = "";

    public Login()
    {
        httpClient = new HttpClient();
    }

    public class LoginParams
    {
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
    }

    public class LoginResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
    //solo para Test //quitar el virtual al ejectuar el proyecto
    virtual public async Task<string> GetLogin()
    {
        LoginResponse loginResponse = new();

        var url = "https://accounts.spotify.com/api/token";

        var formData = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("grant_type", "client_credentials"),
            new KeyValuePair<string, string>("client_id", "e08c093ea1d243ee93b6694a3d12042c"),
            new KeyValuePair<string, string>("client_secret", "e0ae8947b4dc4fdab43aedf2c0d919a6")
        };
        HttpContent content = new FormUrlEncodedContent(formData);

        HttpResponseMessage response = await httpClient.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
            Token = loginResponse.access_token;
        }

        return Token;
    }
}