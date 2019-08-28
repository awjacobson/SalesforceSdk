using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SalesforceSdk.Extensions
{
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Sends a PATCH request to a Uri designated as a string as an asynchronous operation.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="content">The HTTP request content sent to the server.</param>
        /// <returns>This operation will not block. The returned Task<TResult> object will complete after the whole response (including content) is read.</returns>
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient httpClient, string requestUri, HttpContent content)
        {
            // TODO when .NET Standard 2.1 Preview is available, delete this extension method and use the SDK version
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri)
            {
                Content = content
            };
            return await httpClient.SendAsync(request);
        }
    }
}
