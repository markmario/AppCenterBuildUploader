namespace AppCenterBuildUploader.AppCenterApi
{
    public sealed class ReleaseUpdateError : ErrorDetails
    {
        [Newtonsoft.Json.JsonProperty("release_notes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ReleaseNotes { get; set; }

        [Newtonsoft.Json.JsonProperty("mandatory_update", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? MandatoryUpdate { get; set; }

        [Newtonsoft.Json.JsonProperty("destinations", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.ObjectModel.ObservableCollection<DestinationError> Destinations { get; set; }

    }
}