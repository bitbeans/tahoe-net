using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tahoe.Models
{
	/// <summary>
	///     A dictionary that describes the state of the file. For LIT files, this dictionary has only the 'healthy' key, which
	///     will always be True. For distributed files, this dictionary has the following keys in CheckResponseResult.
	/// </summary>
	public class CheckResponseResult
	{
		/// <summary>
		///     The servers-of-happiness level of the file
		/// </summary>
		[JsonProperty("count-happiness")]
		public int CountHappiness { get; set; }

		/// <summary>
		///     For mutable files, the number of unrecoverable versions of the file. For a healthy file, this will be 0.
		/// </summary>
		[JsonProperty("count-unrecoverable-versions")]
		public int CountUnrecoverableVersions { get; set; }

		/// <summary>
		///     The number of distinct storage servers with good shares.Note that a high value does not necessarily imply good
		///     share distribution, because some of these servers may only hold duplicate shares.
		/// </summary>
		[JsonProperty("count-good-share-hosts")]
		public int CountGoodShareHosts { get; set; }

		/// <summary>
		///     The number of good shares that were found
		/// </summary>
		[JsonProperty("count-shares-good")]
		public int CountSharesGood { get; set; }

		/// <summary>
		///     The number of shares with integrity failures
		/// </summary>
		[JsonProperty("count-corrupt-shares")]
		public int CountCorruptShares { get; set; }

		/// <summary>
		///     A list of "share locators", one for each share that was found to be corrupt.Each share locator is a list of
		///     (serverid, storage_index, sharenum).
		/// </summary>
		[JsonProperty("list-corrupt-shares")]
		public List<string> ListCorruptShares { get; set; }

		/// <summary>
		///     'N', the number of total shares generated
		/// </summary>
		[JsonProperty("count-shares-expected")]
		public int CountSharesExpected { get; set; }

		/// <summary>
		///     True if the file is completely healthy, False otherwise.
		///     Healthy files have at least N good shares. Overlapping shares do not currently cause a file to be marked unhealthy.
		///     If there are at least N good shares, then corrupt shares do not cause the file to be marked unhealthy, although the
		///     corrupt shares will be listed in the results (list-corrupt-shares) and should be manually removed to wasting time
		///     in subsequent downloads(as the downloader rediscovers the corruption and uses alternate shares).
		///     Future compatibility: the meaning of this field may change to reflect whether the servers-of-happiness criterion is
		///     met (see ticket #614).
		/// </summary>
		[JsonProperty("healthy")]
		public bool Healthy { get; set; }

		/// <summary>
		///     'k', the number of shares required for recovery.
		/// </summary>
		[JsonProperty("count-shares-needed")]
		public int CountSharesNeeded { get; set; }

		/// <summary>
		///     Dict mapping share identifier to list of serverids (base32-encoded strings). This indicates which servers are
		///     holding which shares.
		///     For immutable files, the shareid is an integer (the share number, from 0 to N-1).
		///     For immutable files, it is a string of the form 'seq%d-%s-sh%d', containing the sequence number, the roothash, and
		///     the share number.
		/// </summary>
		[JsonProperty("sharemap")]
		public object Sharemap { get; set; }

		/// <summary>
		///     For mutable files, the number of recoverable versions of the file. For a healthy file, this will equal 1.
		/// </summary>
		[JsonProperty("count-recoverable-versions")]
		public int CountRecoverableVersions { get; set; }

		/// <summary>
		///     For mutable files, the number of shares for versions other than the 'best' one(highest sequence number, highest
		///     roothash). These are either old, or created by an uncoordinated or not fully successful write.
		/// </summary>
		[JsonProperty("count-wrong-shares")]
		public int CountWrongShares { get; set; }

		/// <summary>
		///     List of base32-encoded storage server identifiers, one for each server which responded to the share query.
		/// </summary>
		[JsonProperty("servers-responding")]
		public List<string> ServersResponding { get; set; }

		/// <summary>
		///     Indicates if the file is recoverable or not.
		/// </summary>
		[JsonProperty("recoverable")]
		public bool Recoverable { get; set; }
	}
}