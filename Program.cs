using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AppCenterBuildUploader.AppCenterApi;
using Newtonsoft.Json.Converters;

namespace AppCenterBuildUploader
{

    class Program
    {
        public const string BaseUrl = "https://api.appcenter.ms";
        public static string OwnerName = string.Empty;
        public static string AppName = string.Empty;
        public static string ApiKey = string.Empty;
        public static string FileName = string.Empty;
        public static readonly List<DestinationId> Destinations = new List<DestinationId>();
        public static string ReleaseNotes = string.Empty;

        static void Main(string[] args)
        {
            Console.WriteLine("Start Upload");

            var ownerName = args.FirstOrDefault(a => a.StartsWith("-ownerName=", StringComparison.OrdinalIgnoreCase));
            if (ownerName != null)
            {
                OwnerName = ownerName.Substring(11);
                args = args.Where(a => a != ownerName).ToArray();
            }

            var appName = args.FirstOrDefault(a => a.StartsWith("-appName=", StringComparison.OrdinalIgnoreCase));
            if (appName != null)
            {
                AppName = appName.Substring(9);
                args = args.Where(a => a != appName).ToArray();
            }

            var apiKey = args.FirstOrDefault(a => a.StartsWith("-apiKey=", StringComparison.OrdinalIgnoreCase));
            if (apiKey != null)
            {
                ApiKey = apiKey.Substring(8);
                args = args.Where(a => a != apiKey).ToArray();
            }

            var fileName = args.FirstOrDefault(a => a.StartsWith("-fileName=", StringComparison.OrdinalIgnoreCase));
            if (fileName != null)
            {
                FileName = fileName.Substring(10);
                args = args.Where(a => a != fileName).ToArray();
            }

            var distrubutionGroups = args.FirstOrDefault(a => a.StartsWith("-distributionGroups=", StringComparison.OrdinalIgnoreCase));
            if (distrubutionGroups != null)
            {
                var distibutionsValue = distrubutionGroups.Substring(20);
                var distributionPairs = distibutionsValue.Split(",");
                foreach (var distributionPair in distributionPairs)
                {
                    var distribution = distributionPair.Split("::");
                    if (distribution.Length == 2)
                    {
                        Destinations.Add(new DestinationId(distribution[0], distribution[1]));
                    }
                }
                args = args.Where(a => a != distrubutionGroups).ToArray();
            }

            var releaseNotes = args.FirstOrDefault(a => a.StartsWith("-releaseNotes=", StringComparison.OrdinalIgnoreCase));
            if (releaseNotes != null)
            {
                ReleaseNotes = releaseNotes.Substring(14);
                args = args.Where(a => a != releaseNotes).ToArray();
            }

            MainAsync(args).GetAwaiter().GetResult();

            Console.WriteLine("Done Uploading");

        }

        static async Task MainAsync(string[] args)
        {
            var client = new AppUploaderClient();
            var result = await client.NewReleaseUploadAsync(OwnerName, AppName, CancellationToken.None);
            var updated = await client.UploadAppAsync(result.UploadUrl, FileName);
            var release = await client.CompleteReleaseUploadAsync(result.UploadId,
                new ReleaseUploadEndRequest()
                {
                    Status = updated ? ReleaseUploadEndRequestStatus.Committed : ReleaseUploadEndRequestStatus.Aborted
                }, OwnerName, AppName,
                CancellationToken.None);
            var lastStep = await client.UpdateReleaseAsync(release.ReleaseId.ToString(),
                new ReleaseUpdateRequest()
                {
                    Destinations = Destinations,
                    MandatoryUpdate = true,
                    ReleaseNotes = ReleaseNotes
                }, OwnerName, AppName, CancellationToken.None);

        }
    }
}