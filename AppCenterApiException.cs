using System;

namespace AppCenterBuildUploader
{
    public sealed class AppCenterApiException<TResult> : AppCenterApiException
    {
        public TResult Result { get; private set; }

        public AppCenterApiException(string message, string statusCode, string response,
            System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers,
            TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            this.Result = result;
        }
    }

    public class AppCenterApiException : Exception
    {
        public string StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> Headers
        {
            get;
            private set;
        }

        public AppCenterApiException(string message, string statusCode, string response,
            System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers,
            System.Exception innerException)
            : base(message, innerException)
        {
            this.StatusCode = statusCode;
            this.Response = response;
            this.Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", this.Response, base.ToString());
        }
    }
}