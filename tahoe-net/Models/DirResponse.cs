using System.Collections.Generic;

namespace Tahoe.Models
{
	public class DirResponse
	{
		public string RwUri { get; set; }
		public string VerifyUri { get; set; }
		public string RoUri { get; set; }
		public bool Mutable { get; set; }
		public List<FileNode> FileNodes { get; set; }
	}
}
