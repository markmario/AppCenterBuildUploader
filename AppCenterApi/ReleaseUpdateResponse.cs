namespace AppCenterBuildUploader.AppCenterApi
{
    public sealed class ReleaseUpdateResponse
    {
        [Newtonsoft.Json.JsonProperty("mandatory_update", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? MandatoryUpdate { get; set; }

        [Newtonsoft.Json.JsonProperty("release_notes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ReleaseNotes { get; set; }

        [Newtonsoft.Json.JsonProperty("destinations", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.ObjectModel.ObservableCollection<DestinationId> Destinations { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static ReleaseUpdateResponse FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ReleaseUpdateResponse>(data);
        }
    }
}