namespace AppCenterBuildUploader.AppCenterApi
{
    /// <summary>A request containing information pertaining to complete a release upload process</summary>
    public sealed class ReleaseUploadEndRequest
    {
        /// <summary>The desired operation for the upload</summary>
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Always)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ReleaseUploadEndRequestStatus Status { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static ReleaseUploadEndRequest FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ReleaseUploadEndRequest>(data);
        }
    }
}