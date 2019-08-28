using Newtonsoft.Json;

namespace SalesforceSdk.Models
{
    public class JobInfo
    {
        /// <summary>
        /// The API version that the job was created in.
        /// </summary>
        [JsonProperty("apiVersion")]
        public decimal? ApiVersion { get; set; }

        /// <summary>
        /// The column delimiter used for CSV job data.
        /// </summary>
        /// <remarks>
        /// Values include:
        /// BACKQUOTE—backquote character(`)
        /// CARET—caret character(^)
        /// COMMA—comma character(,) which is the default delimiter
        /// PIPE—pipe character(|)
        /// SEMICOLON—semicolon character(;)
        /// TAB—tab character
        /// </remarks>
        [JsonProperty("columnDelimiter")]
        public string ColumnDelimiter { get; set; }

        /// <summary>
        /// For future use. How the request was processed. Currently only parallel
        /// mode is supported. (When other modes are added, the mode will be
        /// chosen automatically by the API and will not be user configurable.)
        /// </summary>
        [JsonProperty("concurrencyMode")]
        public string ConcurrencyMode { get; set; }

        /// <summary>
        /// The content type for the job. The only valid value (and the default)
        /// is CSV.
        /// </summary>
        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        /// <summary>
        /// The URL to use for Upload Job Data requests for this job. Only valid
        /// if the job is in Open state.
        /// </summary>
        [JsonProperty("contentUrl")]
        public string ContentUrl { get; set; }

        /// <summary>
        /// The ID of the user who created the job.
        /// </summary>
        [JsonProperty("createdById")]
        public string CreatedById { get; set; }

        /// <summary>
        /// The date and time in the UTC time zone when the job was created.
        /// </summary>
        [JsonProperty("createdDate")]
        public string CreatedDate { get; set; }

        /// <summary>
        /// Unique ID for this job.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The job’s type. Values include:
        /// BigObjectIngest: BigObjects job
        /// Classic: Bulk API 1.0 job
        /// V2Ingest: Bulk API 2.0 job
        /// </summary>
        [JsonProperty("jobType")]
        public string JobType { get; set; }

        /// <summary>
        /// The line ending used for CSV job data, marking the end of a data row.
        /// The default is LF.
        /// </summary>
        /// <remarks>
        ///  Valid values are:
        ///  LF—linefeed character
        ///  CRLF—carriage return character followed by a linefeed character
        /// </remarks>
        [JsonProperty("lineEnding")]
        public string LineEnding { get; set; }

        /// <summary>
        /// The object type for the data being processed. Use only a single object
        /// type per job.
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// The processing operation for the job.
        /// </summary>
        /// <remarks>
        /// The processing operation for the job. Valid values are:
        /// insert
        /// delete
        /// update
        /// upsert
        /// </remarks>
        [JsonProperty("operation")]
        public string Operation { get; set; }

        /// <summary>
        /// The current state of processing for the job.
        /// </summary>
        /// <remarks>
        /// Values include:
        /// Open—The job has been created, and data can be added to the job.
        /// UploadComplete—No new data can be added to this job.You can’t edit or save a closed job.
        /// Aborted—The job has been aborted.You can abort a job if you created it or if you have the “Manage Data Integrations” permission.
        /// JobComplete—The job was processed by Salesforce.
        /// Failed—Some records in the job failed.Job data that was successfully processed isn’t rolled back.
        /// </remarks>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Date and time in the UTC time zone when the job finished.
        /// </summary>
        [JsonProperty("systemModstamp")]
        public string SystemModstamp { get; set; }
    }
}
