namespace AppCenterBuildUploader.AppCenterApi
{
    /// <summary>A response containing information pertaining to starting a release upload process</summary>
    public sealed class ReleaseUploadBeginResponse
    {
        /// <summary>The ID for the current upload</summary>
        [Newtonsoft.Json.JsonProperty("upload_id", Required = Newtonsoft.Json.Required.Always)]
        public string UploadId{ get; set; }

        /// <summary>The URL where the client needs to upload the release to</summary>
        [Newtonsoft.Json.JsonProperty("upload_url", Required = Newtonsoft.Json.Required.Always)]
        public string UploadUrl{ get; set; }

        /// <summary>In preview, the ID for the current upload</summary>
        [Newtonsoft.Json.JsonProperty("asset_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssetId { get; set; }

        /// <summary>In preview, the URL for the current upload</summary>
        [Newtonsoft.Json.JsonProperty("asset_domain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssetDomain { get; set; }

        /// <summary>In preview, the token for the current upload</summary>
        [Newtonsoft.Json.JsonProperty("asset_token", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssetToken { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static ReleaseUploadBeginResponse FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ReleaseUploadBeginResponse>(data);
        }
    }
}