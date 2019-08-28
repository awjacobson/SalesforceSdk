using Newtonsoft.Json;
using System.Collections.Generic;

namespace SalesforceSdk.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <example>
    /// {
    ///   "done":true,
    ///   "nextRecordsUrl":null,
    ///   "records":[
    ///     {
    ///         "id":"............",
    ///         "operation":"insert",
    ///         "object":"Account",
    ///         "createdById":"..............",
    ///         "createdDate":"2019-08-27T21:28:28.000+0000",
    ///         "systemModstamp":"2019-08-27T21:28:28.000+0000",
    ///         "state":"Open",
    ///         "concurrencyMode":"Parallel",
    ///         "contentType":"CSV",
    ///         "apiVersion":46.0,
    ///         "jobType":"V2Ingest",
    ///         "contentUrl":"services/data/v46.0/jobs/ingest/............/batches",
    ///         "lineEnding":"CRLF",
    ///         "columnDelimiter":"COMMA"
    ///     }
    ///   ]}
    /// </example>
    public class GetAllJobsResponse
    {
        [JsonProperty("done")]
        public bool Done { get; set; }

        [JsonProperty("nextRecordsUrl")]
        public string NextRecordsUrl { get; set; }

        [JsonProperty("records")]
        public IList<JobInfo> Records { get; set; }
    }
}
