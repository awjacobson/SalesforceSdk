using Newtonsoft.Json;
using SalesforceSdk.Extensions;
using SalesforceSdk.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace SalesforceSdk.Repositories
{
    public class BulkApiClient : SalesforceClient
    {
        /// <summary>
        /// Creates a job, which represents a bulk operation (and associated data)
        /// that is sent to Salesforce for asynchronous processing
        /// </summary>
        /// <remarks>
        /// https://developer.salesforce.com/docs/atlas.en-us.api_bulk_v2.meta/api_bulk_v2/create_job.htm
        /// </remarks>
        public CreateJobResponse CreateJob()
        {
            var request = new CreateJobRequest
            {
                Object = "Account",
                ContentType = ContentTypes.CSV,
                Operation = Operations.INSERT,
                LineEnding = LineEndings.CRLF
            };
            var stringContent = JsonConvert.SerializeObject(request);
            var content = new StringContent(stringContent, Encoding.UTF8, "application/json");
            var response = _client.PostAsync($"{ApiEndpoint}/jobs/ingest", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                var createJobResponse = JsonConvert.DeserializeObject<CreateJobResponse>(jsonResponse);
                return createJobResponse;
            }

            return null;
        }

        /// <summary>
        /// Uploads data for a job using CSV data you provide.
        /// </summary>
        /// <remarks>
        /// https://developer.salesforce.com/docs/atlas.en-us.api_bulk_v2.meta/api_bulk_v2/upload_job_data.htm#upload_job_data
        /// </remarks>
        /// <param name="contentUrl">
        /// The resource URL is provided in the contentUrl field in the response from
        /// Create a Job, or the response from a Job Info request on an open job.
        /// </param>
        /// <param name="csvContent">
        /// A request can provide CSV data that does not in total exceed 150 MB of
        /// base64 encoded content. When job data is uploaded, it is converted to
        /// base64. This conversion can increase the data size by approximately 50%.
        /// To account for the base64 conversion increase, upload data that does
        /// not exceed 100 MB.
        /// </param>
        public bool UploadJobData(string contentUrl, string csvContent)
        {
            var content = new StringContent(csvContent, Encoding.UTF8, "text/csv");
            var response = _client.PostAsync(contentUrl, content).Result;
            return response.IsSuccessStatusCode;
        }

        public GetAllJobsResponse GetAllJobs()
        {
            var response = _client.GetAsync($"{ApiEndpoint}/jobs/ingest").Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                var getAllJobsResponse = JsonConvert.DeserializeObject<GetAllJobsResponse>(jsonResponse);
                return getAllJobsResponse;
            }

            return null;
        }

        public bool CloseJob(string jobId)
        {
            var closeOrAbortResponse = CloseOrAbortJob(jobId, "UploadComplete");
            return closeOrAbortResponse != null;
        }

        public bool AbortJob(string jobId)
        {
            var closeOrAbortResponse = CloseOrAbortJob(jobId, "Aborted");
            return closeOrAbortResponse != null;
        }

        private CloseOrAbortResponse CloseOrAbortJob(string jobId, string state)
        {
            var request = new CloseOrAbortJobRequest
            {
                State = state
            };
            var stringContent = JsonConvert.SerializeObject(request);
            var content = new StringContent(stringContent, Encoding.UTF8, "application/json");
            var response = _client.PatchAsync($"{ApiEndpoint}/jobs/ingest/{jobId}", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                var closeOrAbortResponse = JsonConvert.DeserializeObject<CloseOrAbortResponse>(jsonResponse);
                return closeOrAbortResponse;
            }

            return null;
        }

        public bool DeleteJob(string jobId)
        {
            var response = _client.DeleteAsync($"{ApiEndpoint}/jobs/ingest/{jobId}").Result;
            return response.IsSuccessStatusCode;
        }
    }
}
