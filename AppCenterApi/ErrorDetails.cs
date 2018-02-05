namespace AppCenterBuildUploader.AppCenterApi
{
    public class ErrorDetails
    {

        [Newtonsoft.Json.JsonProperty("code", Required = Newtonsoft.Json.Required.Always)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ErrorDetailsCode Code { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Always)]
        public string Message { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static ErrorDetails FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorDetails>(data);
        }
    }
}