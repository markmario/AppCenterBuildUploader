namespace AppCenterBuildUploader.AppCenterApi
{
    public sealed class DestinationId
    {
        /// <summary>Name of a distribution group / distribution store. The release will be associated with this distribution group or store. If the distribution group / store doesn't exist a 400 is returned. If both distribution group / store name and id are passed, the id is taking precedence.</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>Id of a distribution group / store. The release will be associated with this distribution group / store. If the distribution group / store doesn't exist a 400 is returned. If both distribution group / store name and id are passed, the id is taking precedence.</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id  { get; set; }

        public DestinationId(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public DestinationId()
        {
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static DestinationId FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<DestinationId>(data);
        }
    }
}