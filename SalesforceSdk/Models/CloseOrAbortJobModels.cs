using Newtonsoft.Json;

namespace SalesforceSdk.Models
{
    public class CloseOrAbortJobRequest
    {
        /// <summary>
        /// The state to update the job to. Use UploadComplete to close a job, or
        /// Aborted to abort a job.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
    }

    public class CloseOrAbortResponse : JobInfo
    {
        /// <summary>
        /// The name of the external ID field for an upsert.
        /// </summary>
        [JsonProperty("externalIdFieldName")]
        public string ExternalIdFieldName { get; set; }
    }
}
