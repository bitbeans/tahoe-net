using Newtonsoft.Json;
using Tahoe.Models;

namespace Tahoe
{
	public static class TahoeGather
	{
		/// <summary>
		///     Convert the Tahoe-LAFS pickle output from the gather service.
		/// </summary>
		/// <param name="rawJson">The converted JSON from pickle2json.py.</param>
		/// <returns>A Gather object.</returns>
		/// <remarks>You need to modify and call: pickle2json.py and pass the output to this method.</remarks>
		public static Gather ConvertGatherOutput(string rawJson)
		{
			var data = JsonConvert.DeserializeObject<Gather>(rawJson);

			data.SummarizedStats = new SummarizedStats
			{
				FilesDownloaded = 0,
				BytesDownloaded = 0,
				BytesUploaded = 0,
				FilesUploaded = 0
			};

			foreach (var server in data.Servers)
			{
				if (server.Data.Counters.DownloaderFilesDownloaded != null)
				{
					data.SummarizedStats.FilesDownloaded = data.SummarizedStats.FilesDownloaded +
					                                       (long) server.Data.Counters.DownloaderFilesDownloaded;
				}
				if (server.Data.Counters.DownloaderBytesDownloaded != null)
				{
					data.SummarizedStats.BytesDownloaded = data.SummarizedStats.BytesDownloaded +
					                                       (long) server.Data.Counters.DownloaderBytesDownloaded;
				}
				if (server.Data.Counters.UploaderBytesUploaded != null)
				{
					data.SummarizedStats.BytesUploaded = data.SummarizedStats.BytesUploaded +
					                                     (long) server.Data.Counters.UploaderBytesUploaded;
				}
				if (server.Data.Counters.UploaderFilesUploaded != null)
				{
					data.SummarizedStats.FilesUploaded = data.SummarizedStats.FilesUploaded +
					                                     (long) server.Data.Counters.UploaderFilesUploaded;
				}
			}

			return data;
		}
	}
}