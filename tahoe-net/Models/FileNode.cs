using System;

namespace Tahoe.Models
{
	public class FileNode
	{
		public string Name { get; set; }
		public string Format { get; set; }
		public string VerifyUri { get; set; }
		public string RoUri { get; set; }
		public bool Mutable { get; set; }
		public long Size { get; set; }
		public DateTime LinkMoTime { get; set; }
		public DateTime LinkCrTime { get; set; }
	}
}
