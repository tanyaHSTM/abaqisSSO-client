using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Providigm.Sso
{
    public class SsoClient
    {
        // Reuse HttpClient
        private static readonly HttpClient Client = new HttpClient();
        private static readonly Uri ProvidigmSsoRequestToken = new Uri("https://test.abaqis.com/sso/request_token");
        private static readonly Uri ProvidigmSsoAbaqisLogin = new Uri("https://test.abaqis.com/sso/token_login");

        public async Task<TokenResponse> RequestTokenAsync(string user, string password)
        {
            var formData = new Dictionary<string, string>
            {
                {"user_full_name", "testuser"},
                {"user_sso_id", "testuser123"},
                {"user_email", "test123@providigm.com"},
                {"cse_type", "c"},
                {"cse_id", "1"},
                {"role_nbr", "stagei,qaadmin,admin,reports,stageii"},
                {"token_time", "900"}
            };
            var request = new HttpRequestMessage(HttpMethod.Post, ProvidigmSsoRequestToken)
            {
                Content = new FormUrlEncodedContent(formData),
                Headers =
                {
                    {"X-HTTP-SSO-ID", user},
                    {"X-HTTP-SSO-PASSWORD", password}
                }
            };

            var response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseText = await response.Content.ReadAsStringAsync();
                return new TokenResponse(responseText);
            }

            throw new Exception($"Request Failed - {response.StatusCode}");
        }

        public async Task<Stream> AbaqisLoginAsync(string token, string onSessionEnd)
        {
            var formData = new Dictionary<string, string>
            {
                {"login_token", token},
                {"onsessionend", onSessionEnd},
            };
            var request = new HttpRequestMessage(HttpMethod.Post, ProvidigmSsoAbaqisLogin)
            {
                Content = new FormUrlEncodedContent(formData),
            };

            var response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                // This actually returns a web page so in your app
                // this would be hosted in a page, etc.
                return await response.Content.ReadAsStreamAsync();
            }

            throw new Exception($"Request Failed - {response.StatusCode}");
        }

        public async Task<HttpResponseMessage> AbaqisLoginPostAsync(string token, string onSessionEnd)
        {
            WebRequestHandler webRequestHandler = new WebRequestHandler {AllowAutoRedirect = false};

            HttpClient httpClient = new HttpClient(webRequestHandler);

            var formData = new Dictionary<string, string>
            {
                {"login_token", token},
                {"onsessionend", onSessionEnd},
            };
            var request = new HttpRequestMessage(HttpMethod.Post, ProvidigmSsoAbaqisLogin)
            {
                Content = new FormUrlEncodedContent(formData),
            };

            var response = await httpClient.SendAsync(request);
            return response;
        }

    }
}