namespace AppCenterBuildUploader.AppCenterApi
{
    public enum ErrorDetailsCode
    {
        [System.Runtime.Serialization.EnumMember(Value = "BadRequest")]
        BadRequest = 0,

        [System.Runtime.Serialization.EnumMember(Value = "Conflict")]
        Conflict = 1,

        [System.Runtime.Serialization.EnumMember(Value = "NotAcceptable")]
        NotAcceptable = 2,

        [System.Runtime.Serialization.EnumMember(Value = "NotFound")]
        NotFound = 3,

        [System.Runtime.Serialization.EnumMember(Value = "InternalServerError")]
        InternalServerError = 4,

        [System.Runtime.Serialization.EnumMember(Value = "Unauthorized")]
        Unauthorized = 5,

        [System.Runtime.Serialization.EnumMember(Value = "TooManyRequests")]
        TooManyRequests = 6,

    }
}