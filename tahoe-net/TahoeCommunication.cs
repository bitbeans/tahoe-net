using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;
using Tahoe.Models;

namespace Tahoe
{
	/// <summary>
	///     Simple class to communicate with a Tahoe-LAFS client REST API.
	/// </summary>
	public static class TahoeCommunication
	{
		/// <summary>
		///     Get informations from a directory.
		/// </summary>
		/// <param name="dir">The directory to request from.</param>
		/// <param name="url">FQDN of the tahoe endpoint.</param>
		/// <returns>A dynamic list.</returns>
		private static List<dynamic> RequestDir(string dir, string url = TahoeDefaults.DefaultTahoeUrl)
		{
			List<dynamic> listResponse;
			try
			{
				if (string.IsNullOrEmpty(dir))
				{
					throw new Exception("Missing dir");
				}
				if (!dir.StartsWith("URI:DIR2:"))
				{
					throw new Exception("Invalid dir address");
				}

				var client = new RestClient(url);
				var request = new RestRequest("uri/{u}", Method.GET);
				request.AddParameter("t", "json");
				request.AddUrlSegment("u", dir);
				var response = client.Execute(request);
				listResponse = JsonConvert.DeserializeObject<List<dynamic>>(response.Content);
			}
			catch (Exception)
			{
				listResponse = null;
			}
			return listResponse;
		}


		/// <summary>
		///		Get informations from a directory.
		/// </summary>
		/// <param name="dir">The directory to request from.</param>
		/// <param name="url">FQDN of the tahoe endpoint.</param>
		/// <returns>A DirResponse object.</returns>
		public static DirResponse GetDir(string dir, string url = TahoeDefaults.DefaultTahoeUrl)
		{
			var dirResponse = new DirResponse();
			try
			{
				if (string.IsNullOrEmpty(dir))
				{
					throw new Exception("Missing dir");
				}
				if (!dir.StartsWith("URI:DIR2:"))
				{
					throw new Exception("Invalid dir address");
				}

				var dirContent = RequestDir(dir, url);

				if (dirContent == null)
				{
					throw new Exception("no response from RequestDir");
				}

				if (!((string) dirContent[0]).Equals("dirnode")) return dirResponse;
				var content = dirContent[1];
				dirResponse.Mutable = content.mutable;
				dirResponse.RoUri = content.ro_uri;
				dirResponse.VerifyUri = content.verify_uri;
				dirResponse.RwUri = content.rw_uri;
				dirResponse.FileNodes = new List<FileNode>();
				foreach (var child in content.children)
				{
					var tmpFileNode = new FileNode {Name = child.Name};
					if (!((string) child.Value[0]).Equals("filenode")) continue;
					var d = child.Value[1];
					tmpFileNode.RoUri = d.ro_uri;
					tmpFileNode.VerifyUri = d.verify_uri;
					tmpFileNode.Mutable = d.mutable;
					tmpFileNode.Size = d.size;
					tmpFileNode.Format = d.format;
					tmpFileNode.LinkMoTime =
						new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(d.metadata.tahoe.linkmotime.Value)
							.ToUniversalTime();
					tmpFileNode.LinkCrTime =
						new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(d.metadata.tahoe.linkcrtime.Value)
							.ToUniversalTime();
					dirResponse.FileNodes.Add(tmpFileNode);
				}
			}
			catch (Exception)
			{
				dirResponse = null;
			}
			return dirResponse;
		}

		/// <summary>
		///		Get informations from a directory as list.
		/// </summary>
		/// <param name="dir">The directory to request from.</param>
		/// <param name="url">FQDN of the tahoe endpoint.</param>
		/// <returns>A list of SimpleFile.</returns>
		public static List<SimpleFile> GetFileList(string dir, string url = TahoeDefaults.DefaultTahoeUrl)
		{
			var securedFiles = new List<SimpleFile>();
			try
			{
				if (string.IsNullOrEmpty(dir))
				{
					throw new Exception("Missing dir");
				}
				if (!dir.StartsWith("URI:DIR2:"))
				{
					throw new Exception("Invalid dir address");
				}

				var dirContent = RequestDir(dir, url);

				if (dirContent == null)
				{
					throw new Exception("no response from RequestDir");
				}

				if (((string) dirContent[0]).Equals("dirnode"))
				{
					var content = dirContent[1];

					foreach (var child in content.children)
					{
						var tmpFile = new SimpleFile {Name = child.Name};
						if (!((string) child.Value[0]).Equals("filenode")) continue;
						var d = child.Value[1];
						tmpFile.Size = d.size;
						tmpFile.Modified =
							new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(d.metadata.tahoe.linkmotime.Value)
								.ToUniversalTime();
						tmpFile.Created =
							new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(d.metadata.tahoe.linkcrtime.Value)
								.ToUniversalTime();
						securedFiles.Add(tmpFile);
					}
				}
			}
			catch (Exception)
			{
				securedFiles = null;
			}
			return securedFiles;
		}

		/// <summary>
		///		Get the used space from a directory.
		/// </summary>
		/// <param name="dir">The directory to request from.</param>
		/// <param name="url">FQDN of the tahoe endpoint.</param>
		/// <returns>The used space.</returns>
		public static long GetUsedSpace(string dir, string url = TahoeDefaults.DefaultTahoeUrl)
		{
			long used = 0;
			try
			{
				if (string.IsNullOrEmpty(dir))
				{
					throw new Exception("Missing dir");
				}
				if (!dir.StartsWith("URI:DIR2:"))
				{
					throw new Exception("Invalid dir address");
				}

				var fileList = GetFileList(url, dir);
				if (fileList != null)
				{
					if (fileList.Count > 0)
					{
						used = fileList.Aggregate<SimpleFile, long>(0,
							(current, file) => current + file.Size);
					}
				}
			}
			catch (Exception)
			{
				used = -1;
			}
			return used;
		}

		/// <summary>
		///		Create a new directory.
		/// </summary>
		/// <param name="url">FQDN of the tahoe endpoint.</param>
		/// <returns>The name of the created directory.</returns>
		public static string CreateDir(string url = TahoeDefaults.DefaultTahoeUrl)
		{
			var alias = string.Empty;
			try
			{
				var client = new RestClient(url + "/uri?t=mkdir");
				var request = new RestRequest(Method.POST);
				var response = client.Execute(request);
				if (response.Content.StartsWith("URI:DIR2:"))
				{
					alias = response.Content;
				}
			}
			catch (Exception)
			{
				alias = string.Empty;
			}
			return alias;
		}
	}
}