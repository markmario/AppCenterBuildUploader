namespace AppCenterBuildUploader.AppCenterApi
{
    /// <summary>A response containing information about the uploaded release.</summary>
    public sealed class ReleaseUploadEndResponse
    {
        /// <summary>The ID of the release.</summary>
        [Newtonsoft.Json.JsonProperty("release_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ReleaseId { get; set; }

        /// <summary>A URL to the new release. If upload was aborted will be null.</summary>
        [Newtonsoft.Json.JsonProperty("release_url", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ReleaseUrl { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static ReleaseUploadEndResponse FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ReleaseUploadEndResponse>(data);
        }

    }
}