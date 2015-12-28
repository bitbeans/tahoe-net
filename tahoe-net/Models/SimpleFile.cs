using System;

namespace Tahoe.Models
{
	public class SimpleFile
	{
		public string Name { get; set; }
		public long Size { get; set; }
		public DateTime Modified { get; set; }
		public DateTime Created { get; set; }
	}
}
