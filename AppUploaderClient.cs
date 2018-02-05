using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppCenterBuildUploader.AppCenterApi;
using Newtonsoft.Json;

namespace AppCenterBuildUploader
{
    public sealed class AppUploaderClient
    {
        private readonly Lazy<JsonSerializerSettings> settings;

        public AppUploaderClient()
        {
            this.settings = new Lazy<JsonSerializerSettings>(() =>
            {
                var settings = new JsonSerializerSettings();
                return settings;
            });
        }

        /// <param name="uploadId">The ID of the upload</param>
        /// <param name="body">The release information</param>
        /// <param name="ownerName">The name of the owner</param>
        /// <param name="appName">The name of the application</param>
        /// <returns>Success</returns>
        /// <exception cref="AppCenterApiException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<ReleaseUploadEndResponse> CompleteReleaseUploadAsync(string uploadId, ReleaseUploadEndRequest body, string ownerName, string appName, CancellationToken cancellationToken)
        {
            if (uploadId == null)
            {
                throw new ArgumentNullException(nameof(uploadId));
            }

            if (ownerName == null)
            {
                throw new ArgumentNullException(nameof(ownerName));
            }

            if (appName == null)
            {
                throw new ArgumentNullException(nameof(appName));
            }

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(Program.BaseUrl.TrimEnd('/'))
                .Append("/v0.1/apps/{owner_name}/{app_name}/release_uploads/{upload_id}");
            urlBuilder.Replace("{upload_id}", Uri.EscapeDataString(uploadId));
            urlBuilder.Replace("{owner_name}", Uri.EscapeDataString(ownerName));
            urlBuilder.Replace("{app_name}", Uri.EscapeDataString(appName));

            using (var client = new HttpClient())
            {
                try
                {
                    using (var request = new HttpRequestMessage())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(body, this.settings.Value));
                        content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        content.Headers.Add("X-API-Token", Program.ApiKey);
                        request.Content = content;
                        request.Method = new HttpMethod("PATCH");
                        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var url = urlBuilder.ToString();
                        request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                        var response = await client
                            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                            .ConfigureAwait(false);
                        try
                        {
                            var headers = response.Headers.ToDictionary(h_ => h_.Key, h_ => h_.Value);
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;

                            var status = ((int) response.StatusCode).ToString();
                            if (status == "200")
                            {
                                var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                                try
                                {
                                    var result =
                                        JsonConvert.DeserializeObject<ReleaseUploadEndResponse>(responseData,
                                            this.settings.Value);
                                    return result;
                                }
                                catch (Exception exception)
                                {
                                    throw new AppCenterApiException("Could not deserialize the response body.", status,
                                        responseData, headers, exception);
                                }
                            }
                            else if (status == "400")
                            {
                                var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new AppCenterApiException(
                                    "Unknown upload_id or status was committed but the upload hasn\'t finished.",
                                    status, responseData, headers, null);
                            }
                            else if (status != "200" && status != "204")
                            {
                                var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new AppCenterApiException(
                                    "The HTTP status code of the response was not expected (" +
                                    (int) response.StatusCode + ").", status, responseData, headers, null);
                            }

                            return default(ReleaseUploadEndResponse);
                        }
                        finally
                        {
                            if (response != null)
                                response.Dispose();
                        }
                    }
                }
                finally
                {
                    client.Dispose();
                }
            }
        }

        /// <param name="ownerName">The name of the owner</param>
        /// <param name="appName">The name of the application</param>
        /// <returns>Success</returns>
        /// <exception cref="AppCenterApiException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<ReleaseUploadBeginResponse> NewReleaseUploadAsync(string ownerName, string appName, CancellationToken cancellationToken)
        {
            if (ownerName == null)
            {
                throw new ArgumentNullException(nameof(ownerName));
            }

            if (appName == null)
            {
                throw new ArgumentNullException(nameof(appName));
            }

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(Program.BaseUrl.TrimEnd('/')).Append("/v0.1/apps/{owner_name}/{app_name}/release_uploads");
            urlBuilder.Replace("{owner_name}", Uri.EscapeDataString(ownerName));
            urlBuilder.Replace("{app_name}", Uri.EscapeDataString(appName));

            using (var client = new HttpClient())
            {
                try
                {
                    using (var request = new HttpRequestMessage())
                    {
                        request.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                        request.Headers.Add("X-API-Token", Program.ApiKey);
                        request.Method = new HttpMethod("POST");
                        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var url = urlBuilder.ToString();
                        request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);


                        var response = await client
                            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                            .ConfigureAwait(false);
                        try
                        {
                            var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                            foreach (var item in response.Content.Headers)
                            {
                                headers[item.Key] = item.Value;
                            }

                            var status = ((int) response.StatusCode).ToString();
                            if (status == "201")
                            {
                                var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                                try
                                {
                                    var result =
                                        JsonConvert.DeserializeObject<ReleaseUploadBeginResponse>(responseData,
                                            this.settings.Value);
                                    return result;
                                }
                                catch (Exception exception)
                                {
                                    throw new AppCenterApiException("Could not deserialize the response body.", status,
                                        responseData, headers, exception);
                                }
                            }
                            else if (status != "200" && status != "204")
                            {
                                var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new AppCenterApiException(
                                    "The HTTP status code of the response was not expected (" +
                                    (int) response.StatusCode + ").", status, responseData, headers, null);
                            }

                            return default(ReleaseUploadBeginResponse);
                        }
                        finally
                        {
                            response.Dispose();
                        }
                    }
                }
                finally
                {
                    client.Dispose();
                }
            }

        }

        public async Task<bool> UploadAppAsync(string url, string fileName)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(5);
                using (var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
                {
                    var appBytes = File.ReadAllBytes(fileName);
                    var name = Path.GetFileName(fileName);
                    content.Add(new StreamContent(new MemoryStream(appBytes)), "ipa", name);

                    using (var message = await client.PostAsync(url, content))
                    {
                        var input = await message.Content.ReadAsStringAsync();
                        return message.IsSuccessStatusCode;
                    }
                }
            }
        }

        /// <param name="releaseId">The ID of the release</param>
        /// <param name="body">The release information.</param>
        /// <param name="ownerName">The name of the owner</param>
        /// <param name="appName">The name of the application</param>
        /// <returns>Success</returns>
        /// <exception cref="AppCenterApiException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<ReleaseUpdateResponse> UpdateReleaseAsync(string releaseId, ReleaseUpdateRequest body, string ownerName, string appName, CancellationToken cancellationToken)
        {
            if (releaseId == null)
            {
                throw new ArgumentNullException(nameof(releaseId));
            }

            if (ownerName == null)
            {
                throw new ArgumentNullException(nameof(ownerName));
            }

            if (appName == null)
            {
                throw new ArgumentNullException(nameof(appName));
            }

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(Program.BaseUrl.TrimEnd('/'))
                .Append("/v0.1/apps/{owner_name}/{app_name}/releases/{release_id}");
            urlBuilder.Replace("{release_id}", Uri.EscapeDataString(releaseId.ToString()));
            urlBuilder.Replace("{owner_name}", Uri.EscapeDataString(ownerName));
            urlBuilder.Replace("{app_name}", Uri.EscapeDataString(appName));

            using (var client = new HttpClient())
            {
                try
                {
                    using (var request = new HttpRequestMessage())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(body, this.settings.Value));
                        content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        content.Headers.Add("X-API-Token",Program.ApiKey);
                        request.Content = content;
                        request.Method = new HttpMethod("PATCH");
                        request.Headers.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));

                        var url = urlBuilder.ToString();
                        request.RequestUri = new Uri(url, System.UriKind.RelativeOrAbsolute);

                        var response = await client
                            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                            .ConfigureAwait(false);
                        try
                        {
                            var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                            foreach (var item in response.Content.Headers)
                            {
                                headers[item.Key] = item.Value;
                            }

                            var status = ((int) response.StatusCode).ToString();
                            if (status == "200")
                            {
                                var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                                try
                                {
                                    var result = JsonConvert.DeserializeObject<ReleaseUpdateResponse>(
                                        responseData, this.settings.Value);
                                    return result;
                                }
                                catch (Exception exception)
                                {
                                    throw new AppCenterApiException("Could not deserialize the response body.", status,
                                        responseData, headers, exception);
                                }
                            }
                            else if (status == "400")
                            {
                                var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var result = default(ReleaseUpdateError);
                                try
                                {
                                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<ReleaseUpdateError>(
                                        responseData, this.settings.Value);
                                }
                                catch (System.Exception exception)
                                {
                                    throw new AppCenterApiException("Could not deserialize the response body.", status,
                                        responseData, headers, exception);
                                }

                                throw new AppCenterApiException<ReleaseUpdateError>("Failure", status, responseData,
                                    headers, result, null);
                            }
                            else
                            {
                                if (status == "404")
                                {
                                    var responseData =
                                        await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                                    var result = default(ErrorDetails);
                                    try
                                    {
                                        result = JsonConvert.DeserializeObject<ErrorDetails>(responseData,
                                            this.settings.Value);
                                    }
                                    catch (Exception exception)
                                    {
                                        throw new AppCenterApiException("Could not deserialize the response body.",
                                            status,
                                            responseData, headers, exception);
                                    }

                                    throw new AppCenterApiException<ErrorDetails>("Release not found", status,
                                        responseData,
                                        headers, result, null);
                                }
                                else if (status != "200" && status != "204")
                                {
                                    var responseData =
                                        await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                                    throw new AppCenterApiException(
                                        "The HTTP status code of the response was not expected (" +
                                        (int) response.StatusCode + ").", status, responseData, headers, null);
                                }
                            }

                            return default(ReleaseUpdateResponse);
                        }
                        finally
                        {
                            if (response != null)
                            {
                                response.Dispose();
                            }
                        }
                    }
                }
                finally
                {
                    client.Dispose();
                }
            }
        }


    }
}