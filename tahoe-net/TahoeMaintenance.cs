using System;
using Newtonsoft.Json;
using RestSharp;
using Tahoe.Models;

namespace Tahoe
{
	/// <summary>
	/// </summary>
	public static class TahoeMaintenance
	{
		/// <summary>
		/// </summary>
		/// <param name="dir"></param>
		/// <param name="verify"></param>
		/// <param name="addLease"></param>
		/// <param name="url"></param>
		/// <param name="taoeMaintenanceOutput"></param>
		/// <returns></returns>
		public static CheckResponse Check(string dir, bool verify = true, bool addLease = true,
			string url = TahoeDefaults.DefaultTahoeUrl,
			TahoeMaintenanceOutput taoeMaintenanceOutput = TahoeMaintenanceOutput.Json)
		{
			CheckResponse checkResponse = null;
			try
			{
				var client = new RestClient(url);
				var request = new RestRequest("uri/{u}", Method.POST);
				request.AddParameter("t", "check");
				request.AddParameter("verify", verify);
				request.AddParameter("add-lease", addLease);

				if (taoeMaintenanceOutput == TahoeMaintenanceOutput.Json)
				{
					request.AddParameter("output", "json");
				}
				request.AddUrlSegment("u", dir);

				var response = client.Execute(request);
				if (response != null)
				{
					try
					{
						checkResponse = JsonConvert.DeserializeObject<CheckResponse>(response.Content);
					}
					catch (JsonReaderException)
					{
						//https://tahoe-lafs.org/trac/tahoe-lafs/ticket/2590
						/*if (response.Content.Contains("UnrecoverableFileError"))
                        {

                        }*/
					}
				}
			}
			catch (Exception)
			{
				checkResponse = null;
			}
			return checkResponse;
		}

		/// <summary>
		/// </summary>
		/// <param name="dir"></param>
		/// <param name="handle"></param>
		/// <param name="repair"></param>
		/// <param name="verify"></param>
		/// <param name="addLease"></param>
		/// <param name="url"></param>
		/// <param name="taoeMaintenanceOutput"></param>
		/// <returns></returns>
		public static DeepCheckResponse DeepCheck(string dir, string handle, bool repair = true, bool verify = true,
			bool addLease = true, string url = TahoeDefaults.DefaultTahoeUrl,
			TahoeMaintenanceOutput taoeMaintenanceOutput = TahoeMaintenanceOutput.Json)
		{
			DeepCheckResponse deepCheckResponse = null;
			try
			{
				var client = new RestClient(url);
				var request = new RestRequest("uri/{u}", Method.POST);
				request.AddParameter("t", "start-deep-check");
				request.AddParameter("repair", repair);
				request.AddParameter("verify", verify);
				request.AddParameter("add-lease", addLease);
				request.AddParameter("ophandle", handle);

				if (taoeMaintenanceOutput == TahoeMaintenanceOutput.Json)
				{
					request.AddParameter("output", "json");
				}
				request.AddUrlSegment("u", dir);

				var response = client.Execute(request);
				if (response != null)
				{
					try
					{
						deepCheckResponse = JsonConvert.DeserializeObject<DeepCheckResponse>(response.Content);
						deepCheckResponse.Handle = handle;
					}
					catch (JsonReaderException)
					{
						//https://tahoe-lafs.org/trac/tahoe-lafs/ticket/2590
						/*if (response.Content.Contains("UnrecoverableFileError"))
                        {

                        }*/
					}
				}
			}
			catch (Exception)
			{
				deepCheckResponse = null;
			}
			return deepCheckResponse;
		}

		/// <summary>
		/// </summary>
		/// <param name="handle"></param>
		/// <param name="releaseHandle"></param>
		/// <param name="url"></param>
		/// <param name="taoeMaintenanceOutput"></param>
		/// <returns></returns>
		public static DeepCheckResponse CheckDeepCheck(string handle, bool releaseHandle = true,
			string url = TahoeDefaults.DefaultTahoeUrl,
			TahoeMaintenanceOutput taoeMaintenanceOutput = TahoeMaintenanceOutput.Json)
		{
			DeepCheckResponse deepCheckResponse = null;
			try
			{
				var client = new RestClient(url);
				var request = new RestRequest("operations/{u}", Method.GET);

				request.AddParameter("release-after-complete", releaseHandle);
				request.AddUrlSegment("u", handle);


				if (taoeMaintenanceOutput == TahoeMaintenanceOutput.Json)
				{
					request.AddParameter("output", "json");
				}

				var response = client.Execute(request);
				if (response != null)
				{
					try
					{
						deepCheckResponse = JsonConvert.DeserializeObject<DeepCheckResponse>(response.Content);
					}
					catch (JsonReaderException)
					{
						//https://tahoe-lafs.org/trac/tahoe-lafs/ticket/2590
						/*if (response.Content.Contains("UnrecoverableFileError"))
                        {

                        }*/
					}
				}
			}
			catch (Exception)
			{
				deepCheckResponse = null;
			}
			return deepCheckResponse;
		}
	}
}