namespace AppCenterBuildUploader.AppCenterApi
{
    public sealed class DestinationError
    {
        /// <summary>Error Codes:<br>
        /// <b>invalid_store_secrets</b>: While distributing to store, secrets provided for store are not valid.<br>
        /// <b>store_release_bad_request</b>: Proper package release details for the store is not provided.<br>
        /// <b>store_release_unauthorized</b>: User is not authorized to publish to store due to invalid developer credentials.<br>
        /// <b>store_release_forbidden</b>: Publish to store is forbidden due to conflicts/errors in the release version and already existing version in the store.<br>
        /// <b>store_release_not_found</b>: App with the given package name is not found in the store.<br>
        /// <b>store_release_not_available</b>: The release is not available.<br>
        /// <b>internal_server_error</b>: Failed to distribute to a destination due to an internal server error.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("code", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Code { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Message { get; set; }
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static DestinationError FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<DestinationError>(data);
        }
    }
}