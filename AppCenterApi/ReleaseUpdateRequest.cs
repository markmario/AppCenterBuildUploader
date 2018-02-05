using System.Collections.Generic;

namespace AppCenterBuildUploader.AppCenterApi
{
  public sealed class ReleaseUpdateRequest
    {
        #region ObsleteCode To be removed in the future
/*
        /// <summary>OBSOLETE. Will be removed in future releases - use destinations instead. Name of a distribution group. The release will be associated with this distribution group. If the distribution group doesn't exist a 400 is returned. If both distribution group name and id are passed, the id is taking precedence.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distribution_group_name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DistributionGroupName { get; set; }

        /// <summary>OBSOLETE. Will be removed in future releases - use destinations instead. Id of a distribution group. The release will be associated with this distribution group. If the distribution group doesn't exist a 400 is returned. If both distribution group name and id are passed, the id is taking precedence.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distribution_group_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DistributionGroupId{ get; set; }

        /// <summary>OBSOLETE. Will be removed in future releases - use destinations instead. Name of a destination. The release will be associated with this destination. If the destination doesn't exist a 400 is returned. If both distribution group name and id are passed, the id is taking precedence.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("destination_name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DestinationName{ get; set; }

        /// <summary>OBSOLETE. Will be removed in future releases - use destinations instead. Id of a destination. The release will be associated with this destination. If the destination doesn't exist a 400 is returned. If both destination name and id are passed, the id is taking precedence.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("destination_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DestinationId{ get; set; }

        /// <summary>Not used anymore.</summary>
        [Newtonsoft.Json.JsonProperty("destination_type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DestinationType{ get; set; }*/
        #endregion

        /// <summary>Release notes for this release.</summary>
        [Newtonsoft.Json.JsonProperty("release_notes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ReleaseNotes{ get; set; }

        /// <summary>A boolean which determines whether this version should be a mandatory update or not.</summary>
        [Newtonsoft.Json.JsonProperty("mandatory_update", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? MandatoryUpdate{ get; set; }

        /// <summary>Distribute this release under the following list of destinations (store groups or distribution groups).</summary>
        [Newtonsoft.Json.JsonProperty("destinations", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<DestinationId> Destinations{ get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static ReleaseUpdateRequest FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ReleaseUpdateRequest>(data);
        }
    }
}