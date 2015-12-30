using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tahoe.Models
{
	public class DeepCheckResponse
	{
		/// <summary>
		///     The handle for this response.
		/// </summary>
		[JsonIgnore]
		public string Handle { get; set; }

		[JsonProperty("count-objects-healthy-post-repair")]
		public int CountObjectsHealthyPostRepair { get; set; }

		[JsonProperty("list-unhealthy-files")]
		public List<object> ListUnhealthyFiles { get; set; }

		[JsonProperty("stats")]
		public DeepCheckStats Stats { get; set; }

		[JsonProperty("count-corrupt-shares-post-repair")]
		public int CountCorruptSharesPostRepair { get; set; }

		[JsonProperty("count-repairs-attempted")]
		public int CountRepairsAttempted { get; set; }

		[JsonProperty("list-remaining-corrupt-shares")]
		public List<object> ListRemainingCorruptShares { get; set; }

		[JsonProperty("count-objects-unhealthy-pre-repair")]
		public int CountObjectsUnhealthyPreRepair { get; set; }

		[JsonProperty("count-repairs-unsuccessful")]
		public int CountRepairsUnsuccessful { get; set; }

		[JsonProperty("finished")]
		public bool Finished { get; set; }

		[JsonProperty("count-objects-unhealthy-post-repair")]
		public int CountObjectsUnhealthyPostRepair { get; set; }

		[JsonProperty("count-corrupt-shares-pre-repair")]
		public int CountCorruptSharesPreRepair { get; set; }

		[JsonProperty("count-objects-healthy-pre-repair")]
		public int CountObjectsHealthyPreRepair { get; set; }

		[JsonProperty("root-storage-index")]
		public string RootStorageIndex { get; set; }

		[JsonProperty("count-objects-checked")]
		public int CountObjectsChecked { get; set; }

		[JsonProperty("list-corrupt-shares")]
		public List<object> ListCorruptShares { get; set; }

		[JsonProperty("count-repairs-successful")]
		public int CountRepairsSuccessful { get; set; }
	}
}