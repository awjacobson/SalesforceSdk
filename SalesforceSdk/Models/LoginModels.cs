using Newtonsoft.Json;

namespace SalesforceSdk.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// For more info:
    /// Understanding the Username-Password OAuth Authentication Flow
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/intro_understanding_username_password_oauth_flow.htm
    /// </remarks>
    /// <example>
    /// {
    ///   "access_token" : "................................................",
    ///   "instance_url" : "https://.......salesforce.com",
    ///   "id" : "https://test.salesforce.com/id/......../............",
    ///   "token_type" : "Bearer",
    ///   "issued_at" : "1566931702639",
    ///   "signature" : "....................."
    /// }
    /// </example>
    public class LoginResponse
    {
        /// <summary>
        /// Access token that acts as a session ID that the application uses for 
        /// making requests. This token should be protected as though it were user
        /// credentials.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Identifies the Salesforce instance to which API calls are sent.
        /// </summary>
        [JsonProperty("instance_url")]
        public string InstanceUrl { get; set; }

        /// <summary>
        /// Identity URL that can be used to both identify the user and query for
        /// more information about the user. Can be used in an HTTP request to get
        /// more information about the end user.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// When the signature was created, represented as the number of seconds
        /// since the Unix epoch (00:00:00 UTC on 1 January 1970).
        /// </summary>
        [JsonProperty("issued_at")]
        public string IssuedAt { get; set; }

        /// <summary>
        /// Base64-encoded HMAC-SHA256 signature signed with the client_secret
        /// (private key) containing the concatenated ID and issued_at value.
        /// Use the signature to verify that the identity URL wasn’t modified
        /// when the server sent it.
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; }
    }
}
