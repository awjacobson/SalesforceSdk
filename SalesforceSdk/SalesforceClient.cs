using Newtonsoft.Json;
using SalesforceSdk.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SalesforceSdk
{
    public interface ISalesforceClient
    {
        bool Login();
    }

    /// <summary>
    /// Salesforce Developer Center: Integration and APIs
    /// https://developer.salesforce.com/developer-centers/integration-apis/
    /// </summary>
    public class SalesforceClient : ISalesforceClient, IDisposable
    {
        protected const string LOGIN_ENDPOINT = "/services/oauth2/token";
        protected HttpClient _client;

        /// <summary>
        /// If you’re verifying authentication on a sandbox organization, use “test.salesforce.com”
        /// instead of “login.salesforce.com” in all the OAuth endpoints.
        /// </summary>
        protected string BaseAddress => IsSandbox ? "https://test.salesforce.com" : "https://login.salesforce.com";

        /// <summary>
        /// Gets the API enpoint url with the given version.
        /// </summary>
        protected string ApiEndpoint => $"/services/data/v{Version}";

        public bool IsSandbox { get; set; }

        /// <summary>
        /// Default value is 46.0
        /// </summary>
        public string Version { get; set; } = "46.0";
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AccessToken { get; set; }
        public string InstanceUrl { get; set; }

        static SalesforceClient()
        {
            // SF requires TLS 1.1 or 1.2
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
        }

        public bool Login()
        {
            using (var client = new HttpClient() { BaseAddress = new Uri(BaseAddress) })
            {
                var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"grant_type", "password"},
                    {"client_id", ClientId},
                    {"client_secret", ClientSecret},
                    {"username", Username},
                    {"password", Password}
                });
                content.Headers.Add("X-PrettyPrint", "1");
                var response = client.PostAsync(LOGIN_ENDPOINT, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = response.Content.ReadAsStringAsync().Result;
                    var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(jsonResponse);
                    /*
                     * Create a new HttpClient using the instance url returned from the login call.
                     */
                    _client = new HttpClient() { BaseAddress = new Uri(loginResponse.InstanceUrl) };
                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.AccessToken);
                    AccessToken = loginResponse.AccessToken;
                    InstanceUrl = loginResponse.InstanceUrl;
                    return true;
                }
            }
            return false;
        }

        public void Dispose()
        {
            if (_client == null)
            {
                _client.Dispose();
            }
        }
    }
}
