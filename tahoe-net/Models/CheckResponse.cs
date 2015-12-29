using Newtonsoft.Json;

namespace Tahoe.Models
{
	/// <summary>
	///     Class to represent a t=check response.
	/// </summary>
	/// <see cref="https://tahoe-lafs.org/trac/tahoe-lafs/browser/trunk/docs/frontends/webapi.rst#other-utilities" />
	public class CheckResponse
	{
		/// <summary>
		///     A dictionary that describes the state of the file. For LIT files, this dictionary has only the 'healthy' key, which
		///     will always be True. For distributed files, this dictionary has the following keys in CheckResponseResult.
		/// </summary>
		[JsonProperty("results")]
		public CheckResponseResult CheckResponseResult { get; set; }

		/// <summary>
		///     A base32-encoded string with the objects's storage index, or an empty string for LIT files.
		/// </summary>
		[JsonProperty("storage-index")]
		public string StorageIndex { get; set; }

		/// <summary>
		///     A string, with a one-line summary of the stats of the file.
		/// </summary>
		[JsonProperty("summary")]
		public string Summary { get; set; }
	}
}