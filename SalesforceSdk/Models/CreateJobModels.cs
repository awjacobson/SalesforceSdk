using Newtonsoft.Json;

namespace SalesforceSdk.Models
{
    public class CreateJobRequest
    {
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
        [JsonProperty("columnDelimiter", NullValueHandling = NullValueHandling.Ignore)]
        public string ColumnDelimiter { get; set; }

        /// <summary>
        /// The content type for the job. The only valid value (and the default)
        /// is CSV.
        /// </summary>
        [JsonProperty("contentType", NullValueHandling = NullValueHandling.Ignore)]
        public string ContentType { get; set; }

        /// <summary>
        /// The external ID field in the object being updated. Only needed for
        /// upsert operations. Field values must also exist in CSV job data.
        /// </summary>
        [JsonProperty("externalIdFieldName", NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalIdFieldName { get; set; }

        /// <summary>
        /// The line ending used for CSV job data, marking the end of a data row.
        /// The default is LF.
        /// </summary>
        /// <remarks>
        ///  Valid values are:
        ///  LF—linefeed character
        ///  CRLF—carriage return character followed by a linefeed character
        /// </remarks>
        [JsonProperty("lineEnding", NullValueHandling = NullValueHandling.Ignore)]
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
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// {
    ///   "id":"...........",
    ///   "operation":"insert",
    ///   "object":"Account",
    ///   "createdById":".............",
    ///   "createdDate":"2019-08-27T21:28:28.000+0000",
    ///   "systemModstamp":"2019-08-27T21:28:28.000+0000",
    ///   "state":"Open",
    ///   "concurrencyMode":"Parallel",
    ///   "contentType":"CSV",
    ///   "apiVersion":46.0,
    ///   "contentUrl":"services/data/v46.0/jobs/ingest/............/batches",
    ///   "lineEnding":"CRLF",
    ///   "columnDelimiter":"COMMA"
    /// }
    /// </remarks>
    public class CreateJobResponse : JobInfo
    {
        [JsonProperty("externalIdFieldName")]
        public string ExternalIdFieldName { get; set; }
    }

    public static class Objects
    {
        public static readonly string CONTACT = "Contact";
    }

    public static class ColumnDelimiters
    {
        public static readonly string BACKQUOTE = "BACKQUOTE";
        public static readonly string CARET = "CARET";
        public static readonly string COMMA = "COMMA";
    }

    public static class ContentTypes
    {
        public static readonly string CSV = "CSV";
    }

    public static class LineEndings
    {
        /// <summary>
        /// linefeed character
        /// </summary>
        public static readonly string LF = "LF";

        /// <summary>
        /// carriage return character followed by a linefeed character
        /// </summary>
        public static readonly string CRLF = "CRLF";
    }

    public static class Operations
    {
        public static readonly string INSERT = "insert";
        public static readonly string DELETE = "delete";
        public static readonly string UPDATE = "update";
        public static readonly string UPSERT = "upsert";
    }

    public static class States
    {
        /// <summary>
        /// The job was created and is open for data uploads.
        /// </summary>
        public static readonly string OPEN = "Open";

        /// <summary>
        /// All job data has been uploaded and the job is ready to be processed.
        /// Salesforce has put the job in the queue.
        /// </summary>
        public static readonly string UPLOADCOMPLETE = "UploadComplete";

        /// <summary>
        /// The job is being processed by Salesforce. This includes automatic
        /// optimized chunking of job data and processing of job operations.
        /// </summary>
        public static readonly string INPROGRESS = "InProgress";

        /// <summary>
        /// The job was processed.
        /// </summary>
        public static readonly string JOBCOMPLETE = "JobComplete";

        /// <summary>
        /// The job was canceled by the job creator, or by a user with the
        /// “Manage Data Integrations” permission.
        /// </summary>
        public static readonly string ABORTED = "Aborted";

        public static readonly string FAILED = "Failed";
    }
}
