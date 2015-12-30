using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tahoe.Models
{
	public class DeepCheckStats
	{
		[JsonProperty("count-immutable-files")]
		public int CountImmutableFiles { get; set; }

		[JsonProperty("count-literal-files")]
		public int CountLiteralFiles { get; set; }

		[JsonProperty("largest-directory-children")]
		public long LargestDirectoryChildren { get; set; }

		[JsonProperty("largest-directory")]
		public long LargestDirectory { get; set; }

		[JsonProperty("size-directories")]
		public long SizeDirectories { get; set; }

		[JsonProperty("largest-immutable-file")]
		public long LargestImmutableFile { get; set; }

		[JsonProperty("size-files-histogram")]
		public List<List<long>> SizeFilesHistogram { get; set; }

		[JsonProperty("size-immutable-files")]
		public long SizeImmutableFiles { get; set; }

		[JsonProperty("count-unknown")]
		public int CountUnknown { get; set; }

		[JsonProperty("count-files")]
		public int CountFiles { get; set; }

		[JsonProperty("count-mutable-files")]
		public int CountMutableFiles { get; set; }

		[JsonProperty("count-directories")]
		public int CountDirectories { get; set; }

		[JsonProperty("size-literal-files")]
		public long SizeLiteralFiles { get; set; }
	}
}