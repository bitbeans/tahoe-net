using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tahoe.Models
{
	/// <summary>
	///     Class to serialize a formatted/converted Tahoe-LAFS gather output.
	/// </summary>
	public class Gather
	{
		/// <summary>
		///     List of the available and gathered servers.
		/// </summary>
		public List<Server> Servers { get; set; }

		/// <summary>
		///     Some extra and summarized stats.
		/// </summary>
		public SummarizedStats SummarizedStats { get; set; }
	}

	/// <summary>
	///     Some extra and summarized stats.
	/// </summary>
	public class SummarizedStats
	{
		public long FilesDownloaded { get; set; }
		public long FilesUploaded { get; set; }
		public long BytesDownloaded { get; set; }
		public long BytesUploaded { get; set; }
	}

	/// <summary>
	///     Object holds the counter and stats data of each server.
	/// </summary>
	public class Data
	{
		/// <summary>
		///     'counters' are strictly counters: they are reset to zero when the node is started, and grow upwards.
		/// </summary>
		public Counters Counters { get; set; }

		/// <summary>
		///     'stats' are non-incrementing values, used to measure the current state of various systems.
		/// </summary>
		public Stats Stats { get; set; }
	}

	/// <summary>
	///     Holds the common information of the server.
	///     It also holds the related counter and stats data.
	/// </summary>
	public class Server
	{
		/// <summary>
		///     Holds the Counter and Stats object of the server.
		/// </summary>
		public Data Data { get; set; }

		/// <summary>
		///     The nickname of the server, he use in the grid.
		/// </summary>
		public string Nickname { get; set; }

		/// <summary>
		///     The timestamp, this data was last refreshed.
		/// </summary>
		public double Timestamp { get; set; }

		/// <summary>
		///     The formatted timestamp, this data was last refreshed.
		/// </summary>
		public DateTime TimestampFormatted
		{
			get
			{
				var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
				dtDateTime = dtDateTime.AddSeconds(Timestamp).ToLocalTime();
				return dtDateTime;
			}
		}
	}

	/// <summary>
	///     'stats' are non-incrementing values, used to measure the current state of various systems.
	/// </summary>
	public class Stats
	{
		//TODO: add missing latencies and make better description
		/// <summary>
		///     Estimate of what percentage of system CPU time was consumed by the node process, over a 1 minute interval.
		///     Expressed as a float, 0.0 for 0%, 1.0 for 100%
		/// </summary>
		[JsonProperty("cpu_monitor.1min_avg")]
		public double CpuMonitor1MinAvg { get; set; }

		/// <summary>
		///     Estimate of what percentage of system CPU time was consumed by the node process, over a 5 minute interval.
		///     Expressed as a float, 0.0 for 0%, 1.0 for 100%
		/// </summary>
		[JsonProperty("cpu_monitor.5min_avg")]
		public double CpuMonitor5MinAvg { get; set; }

		/// <summary>
		///     Estimate of what percentage of system CPU time was consumed by the node process, over a 15 minute interval.
		///     Expressed as a float, 0.0 for 0%, 1.0 for 100%
		/// </summary>
		[JsonProperty("cpu_monitor.15min_avg")]
		public double CpuMonitor15MinAvg { get; set; }

		/// <summary>
		///     Estimate of total number of CPU seconds consumed by node since the process was started.
		/// </summary>
		[JsonProperty("cpu_monitor.total")]
		public double CpuMonitorTotal { get; set; }

		/// <summary>
		///     When enabled, the "load monitor" continually schedules a one-second callback,
		///     and measures how late the response is.
		///     This estimates system load (if the system is idle, the response should be on time).
		///     Average "load" value (seconds late) over the last minute.
		/// </summary>
		/// <remarks>This is only enabled if a stats-gatherer is configured.</remarks>
		[JsonProperty("load_monitor.avg_load")]
		public double LoadMonitorAvgLoad { get; set; }

		/// <summary>
		///     When enabled, the "load monitor" continually schedules a one-second callback,
		///     and measures how late the response is.
		///     This estimates system load (if the system is idle, the response should be on time).
		///     Maximum "load" value over the last minute.
		/// </summary>
		/// <remarks>This is only enabled if a stats-gatherer is configured.</remarks>
		[JsonProperty("load_monitor.max_load")]
		public double LoadMonitorMaxLoad { get; set; }

		/// <summary>
		///     How many seconds since the node process was started.
		/// </summary>
		[JsonProperty("node.uptime")]
		public double NodeUptime { get; set; }

		/// <summary>
		///     This tracks Helper activity.
		///     'active_uploads' how many files are currently being uploaded. 0 when idle.
		/// </summary>
		/// <remarks>Only provided by upload helpers.</remarks>
		[JsonProperty("chk_upload_helper.active_uploads")]
		public int? ChkUploadHelperActiveUploads { get; set; }

		/// <summary>
		///     This tracks Helper activity.
		///     'incoming_count' how many cache files are present in the incoming/ directory, which holds ciphertext files that are
		///     still being fetched from the client.
		/// </summary>
		/// <remarks>Only provided by upload helpers.</remarks>
		[JsonProperty("chk_upload_helper.incoming_count")]
		public int? ChkUploadHelperIncomingCount { get; set; }

		/// <summary>
		///     This tracks Helper activity.
		///     'incoming_size' total size of cache files in the incoming/ directory.
		/// </summary>
		/// <remarks>Only provided by upload helpers.</remarks>
		[JsonProperty("chk_upload_helper.incoming_size")]
		public long? ChkUploadHelperIncomingSize { get; set; }

		/// <summary>
		///     This tracks Helper activity.
		///     'incoming_size_old' total size of 'old' cache files (more than 48 hours).
		/// </summary>
		/// <remarks>Only provided by upload helpers.</remarks>
		[JsonProperty("chk_upload_helper.incoming_size_old")]
		public long? ChkUploadHelperIncomingSizeOld { get; set; }

		/// <summary>
		///     This tracks Helper activity.
		///     'encoding_count' how many cache files are present in the encoding/ directory, which holds ciphertext files that are
		///     being encoded and uploaded.
		/// </summary>
		/// <remarks>Only provided by upload helpers.</remarks>
		[JsonProperty("chk_upload_helper.encoding_count")]
		public int? ChkUploadHelperEncodingCount { get; set; }

		/// <summary>
		///     This tracks Helper activity.
		///     'encoding_size' total size of cache files in the encoding/ directory.
		/// </summary>
		/// <remarks>Only provided by upload helpers.</remarks>
		[JsonProperty("chk_upload_helper.encoding_size")]
		public long? ChkUploadHelperEncodingSize { get; set; }

		/// <summary>
		///     This tracks Helper activity.
		///     'encoding_size_old' total size of 'old' cache files (more than 48 hours).
		/// </summary>
		/// <remarks>Only provided by upload helpers.</remarks>
		[JsonProperty("chk_upload_helper.encoding_size_old")]
		public long? ChkUploadHelperEncodingSizeOld { get; set; }

		/// <summary>
		///     This is 'true' if the storage server is currently accepting uploads of immutable shares.
		///     It may be 'false' if a server is disabled by configuration, or if the disk is full
		///     (i.e. disk_avail is less than reserved_space).
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.accepting_immutable_shares")]
		public bool? StorageServerAcceptingImmutableShares { get; set; }

		/// <summary>
		///     This counts how many bytes are currently 'allocated', which tracks the space that will eventually be consumed by
		///     immutable share upload operations.
		///     The stat is increased as soon as the upload begins (at the same time the 'allocated' counter is incremented),
		///     and goes back to zero when the 'close' or 'abort' message is received (at which point the 'disk_used' stat should
		///     incremented by the same amount).
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.allocated")]
		public long? StorageServerAllocated { get; set; }

		/// <summary>
		///     This reflect disk-space usage policies and status.
		///     'disk_avail' reports the remaining disk space available for the Tahoe server after subtracting reserved_space from
		///     disk_avail.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.disk_avail")]
		public long? StorageServerDiskAvailable { get; set; }

		/// <summary>
		///     This reflect disk-space usage policies and status.
		///     'disk_free_for_nonroot' show related information.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.disk_free_for_nonroot")]
		public long? StorageServerDiskFreeForNonroot { get; set; }

		/// <summary>
		///     This reflect disk-space usage policies and status.
		///     'disk_free_for_root' show related information.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.disk_free_for_root")]
		public long? StorageServerDiskFreeForRoot { get; set; }

		/// <summary>
		///     This reflect disk-space usage policies and status.
		///     'disk_total' is the total size of disk where the storage server's BASEDIR/storage/shares directory lives, as
		///     reported by /bin/df or equivalent.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.disk_total")]
		public long? StorageServerDiskTotal { get; set; }

		/// <summary>
		///     This reflect disk-space usage policies and status.
		///     'disk_used' show related information.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.disk_used")]
		public long? StorageServerDiskUsed { get; set; }

		/// <summary>
		///     /// This reflect disk-space usage policies and status.
		///     'reserved_space' reports the reservation configured by the tahoe.cfg [storage]reserved_space value.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.reserved_space")]
		public long? StorageServerReservedSpace { get; set; }

		/// <summary>
		///     This counts the number of 'buckets' (i.e. unique storage-index values) currently managed by the storage server.
		///     It indicates roughly how many files are managed by the server.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.total_bucket_count")]
		public int? StorageServerTotalBucketCount { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for get operations.
		///     'storage_server.latencies.get.01_0_percentile' records the median response time for a 'get' request.
		///     The unit is seconds.
		///     The value means that 1 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.get.01_0_percentile")]
		public double? StorageServerLatenciesGet010Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for get operations.
		///     'storage_server.latencies.get.10_0_percentile' records the median response time for a 'get' request.
		///     The unit is seconds.
		///     The value means that 10 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.get.10_0_percentile")]
		public double? StorageServerLatenciesGet100Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for get operations.
		///     'storage_server.latencies.get.50_0_percentile' records the median response time for a 'get' request.
		///     The unit is seconds.
		///     The value means that 50 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.get.50_0_percentile")]
		public double? StorageServerLatenciesGet500Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for get operations.
		///     'storage_server.latencies.get.90_0_percentile' records the median response time for a 'get' request.
		///     The unit is seconds.
		///     The value means that 90 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.get.90_0_percentile")]
		public double? StorageServerLatenciesGet900Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for get operations.
		///     'storage_server.latencies.get.95_0_percentile' records the median response time for a 'get' request.
		///     The unit is seconds.
		///     The value means that 95 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.get.95_0_percentile")]
		public double? StorageServerLatenciesGet950Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for get operations.
		///     'storage_server.latencies.get.99_0_percentile' records the median response time for a 'get' request.
		///     The unit is seconds.
		///     The value means that 99 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.get.99_0_percentile")]
		public double? StorageServerLatenciesGet990Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for get operations.
		///     'storage_server.latencies.get.99_9_percentile' records the median response time for a 'get' request.
		///     The unit is seconds.
		///     The value means that 99.9 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.get.99_9_percentile")]
		public double? StorageServerLatenciesGet999Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for get operations.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.get.mean")]
		public double? StorageServerLatenciesGetMean { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for get operations.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.get.samplesize")]
		public int? StorageServerLatenciesGetSamplesize { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for read operations.
		///     'storage_server.latencies.read.01_0_percentile' records the median response time for a 'read' request.
		///     The unit is seconds.
		///     The value means that 1 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.read.01_0_percentile")]
		public double? StorageServerLatenciesRead010Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for read operations.
		///     'storage_server.latencies.read.10_0_percentile' records the median response time for a 'read' request.
		///     The unit is seconds.
		///     The value means that 10 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.read.10_0_percentile")]
		public double? StorageServerLatenciesRead100Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for read operations.
		///     'storage_server.latencies.read.50_0_percentile' records the median response time for a 'read' request.
		///     The unit is seconds.
		///     The value means that 50 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.read.50_0_percentile")]
		public double? StorageServerLatenciesRead500Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for read operations.
		///     'storage_server.latencies.read.90_0_percentile' records the median response time for a 'read' request.
		///     The unit is seconds.
		///     The value means that 90 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.read.90_0_percentile")]
		public double? StorageServerLatenciesRead900Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for read operations.
		///     'storage_server.latencies.read.95_0_percentile' records the median response time for a 'read' request.
		///     The unit is seconds.
		///     The value means that 95 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.read.95_0_percentile")]
		public double? StorageServerLatenciesRead950Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for read operations.
		///     'storage_server.latencies.read.99_0_percentile' records the median response time for a 'read' request.
		///     The unit is seconds.
		///     The value means that 99 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.read.99_0_percentile")]
		public double? StorageServerLatenciesRead990Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for read operations.
		///     'storage_server.latencies.read.99_9_percentile' records the median response time for a 'read' request.
		///     The unit is seconds.
		///     The value means that 99.9 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.read.99_9_percentile")]
		public double? StorageServerLatenciesRead999Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for read operations.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.read.mean")]
		public double? StorageServerLatenciesReadMean { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for read operations.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.read.samplesize")]
		public int? StorageServerLatenciesReadSamplesize { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for readv operations.
		///     'storage_server.latencies.readv.01_0_percentile' records the median response time for a 'readv' request.
		///     The unit is seconds.
		///     The value means that 1 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.readv.01_0_percentile")]
		public double? StorageServerLatenciesReadv010Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for readv operations.
		///     'storage_server.latencies.readv.10_0_percentile' records the median response time for a 'readv' request.
		///     The unit is seconds.
		///     The value means that 10 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.readv.10_0_percentile")]
		public double? StorageServerLatenciesReadv100Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for readv operations.
		///     'storage_server.latencies.readv.50_0_percentile' records the median response time for a 'readv' request.
		///     The unit is seconds.
		///     The value means that 50 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.readv.50_0_percentile")]
		public double? StorageServerLatenciesReadv500Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for readv operations.
		///     'storage_server.latencies.readv.90_0_percentile' records the median response time for a 'readv' request.
		///     The unit is seconds.
		///     The value means that 90 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.readv.90_0_percentile")]
		public double? StorageServerLatenciesReadv900Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for readv operations.
		///     'storage_server.latencies.readv.95_0_percentile' records the median response time for a 'readv' request.
		///     The unit is seconds.
		///     The value means that 95 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.readv.95_0_percentile")]
		public double? StorageServerLatenciesReadv950Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for readv operations.
		///     'storage_server.latencies.readv.99_0_percentile' records the median response time for a 'readv' request.
		///     The unit is seconds.
		///     The value means that 99 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.readv.99_0_percentile")]
		public double? StorageServerLatenciesReadv990Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for readv operations.
		///     'storage_server.latencies.readv.StorageServerLatencies_readv_99_9_percentile' records the median response time for
		///     a 'readv' request.
		///     The unit is seconds.
		///     The value means that 99.9 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.readv.99_9_percentile")]
		public double? StorageServerLatenciesReadv999Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for readv operations.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.readv.mean")]
		public double? StorageServerLatenciesReadvMean { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for readv operations.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.readv.samplesize")]
		public int? StorageServerLatenciesReadvSamplesize { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for writev operations.
		///     'storage_server.latencies.writev.01_0_percentile' records the median response time for a 'writev' request.
		///     The unit is seconds.
		///     The value means that 1 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.writev.01_0_percentile")]
		public double? StorageServerLatenciesWritev010Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for writev operations.
		///     'storage_server.latencies.writev.10_0_percentile' records the median response time for a 'writev' request.
		///     The unit is seconds.
		///     The value means that 10 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.writev.10_0_percentile")]
		public double? StorageServerLatenciesWritev100Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for writev operations.
		///     'storage_server.latencies.writev.50_0_percentile' records the median response time for a 'writev' request.
		///     The unit is seconds.
		///     The value means that 50 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.writev.50_0_percentile")]
		public double? StorageServerLatenciesWritev500Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for writev operations.
		///     'storage_server.latencies.writev.90_0_percentile' records the median response time for a 'writev' request.
		///     The unit is seconds.
		///     The value means that 90 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.writev.90_0_percentile")]
		public double? StorageServerLatenciesWritev900Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for writev operations.
		///     'storage_server.latencies.writev.95_0_percentile' records the median response time for a 'writev' request.
		///     The unit is seconds.
		///     The value means that 95 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.writev.95_0_percentile")]
		public double? StorageServerLatenciesWritev950Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for writev operations.
		///     'storage_server.latencies.writev.99_0_percentile' records the median response time for a 'writev' request.
		///     The unit is seconds.
		///     The value means that 99 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.writev.99_0_percentile")]
		public double? StorageServerLatenciesWritev990Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for writev operations.
		///     'storage_server.latencies.writev.99_9_percentile' records the median response time for a 'writev' request.
		///     The unit is seconds.
		///     The value means that 99.9 out of of the last 1000 operations were faster than the given number.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.writev.99_9_percentile")]
		public double? StorageServerLatenciesWritev999Percentile { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for writev operations.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.writev.mean")]
		public double? StorageServerLatenciesWritevMean { get; set; }

		/// <summary>
		///     This keeps track of local disk latencies for writev operations.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.latencies.writev.samplesize")]
		public int? StorageServerLatenciesWritevSamplesize { get; set; }
	}

	/// <summary>
	///     'counters' are strictly counters: they are reset to zero when the node is started, and grow upwards.
	/// </summary>
	public class Counters
	{
		/// <summary>
		///     This counts the activity of the "Helper".
		///     Incremented each time a client asks to upload a file.
		/// </summary>
		/// <remarks>Only provided by upload helpers.</remarks>
		[JsonProperty("chk_upload_helper.upload_requests")]
		public long? ChkUploadHelperUploadRequests { get; set; }

		/// <summary>
		///     This counts the activity of the "Helper".
		///     upload_already_present: incremented when the file is already in the grid.
		/// </summary>
		/// <remarks>Only provided by upload helpers.</remarks>
		[JsonProperty("chk_upload_helper.upload_already_present")]
		public long? ChkUploadHelperUploadAlreadyPresents { get; set; }

		/// <summary>
		///     This counts the activity of the "Helper".
		///     Incremented when the file is not already in the grid.
		/// </summary>
		/// <remarks>Only provided by upload helpers.</remarks>
		[JsonProperty("chk_upload_helper.upload_need_upload")]
		public long? ChkUploadHelperUploadNeedUpload { get; set; }

		/// <summary>
		///     This counts the activity of the "Helper".
		///     Incremented when the helper already has partial ciphertext for the requested upload,
		///     indicating that the client is resuming an earlier upload
		/// </summary>
		/// <remarks>Only provided by upload helpers.</remarks>
		[JsonProperty("chk_upload_helper.resumes")]
		public long? ChkUploadHelperResumes { get; set; }

		/// <summary>
		///     This counts the activity of the "Helper".
		///     This counts how many bytes of ciphertext have been fetched from uploading clients.
		/// </summary>
		/// <remarks>Only provided by upload helpers.</remarks>
		[JsonProperty("chk_upload_helper.fetched_bytes")]
		public long? ChkUploadHelperFetchedBytes { get; set; }

		/// <summary>
		///     This counts the activity of the "Helper".
		///     This counts how many bytes of ciphertext have been encoded and turned into successfully-uploaded shares.
		///     If no uploads have failed or been abandoned, encoded_bytes should eventually equal fetched_bytes.
		/// </summary>
		/// <remarks>Only provided by upload helpers.</remarks>
		[JsonProperty("chk_upload_helper.encoded_bytes")]
		public long? ChkUploadHelperEncodedBytes { get; set; }

		/// <summary>
		///     This counts the client activity.
		///     A Tahoe client will increment this when it uploads an immutable file.
		///     'bytes_uploaded' is incremented by the size of the file.
		/// </summary>
		/// <remarks>Only provided by client servers.</remarks>
		[JsonProperty("uploader.bytes_uploaded")]
		public long? UploaderBytesUploaded { get; set; }

		/// <summary>
		///     This counts the client activity.
		///     A Tahoe client will increment this when it uploads an immutable file.
		///     'files_uploaded' is incremented by one for each operation.
		/// </summary>
		/// <remarks>Only provided by client servers.</remarks>
		[JsonProperty("uploader.files_uploaded")]
		public long? UploaderFilesUploaded { get; set; }

		/// <summary>
		///     This counts the client activity.
		///     A Tahoe client will increment this when it downloads an immutable file.
		///     'bytes_downloaded' is incremented by the size of the file.
		/// </summary>
		/// <remarks>Only provided by client servers.</remarks>
		[JsonProperty("downloader.bytes_downloaded")]
		public long? DownloaderBytesDownloaded { get; set; }

		/// <summary>
		///     This counts the client activity.
		///     A Tahoe client will increment this when it downloads an immutable file.
		///     'files_downloaded' is incremented by one for each operation.
		/// </summary>
		/// <remarks>Only provided by client servers.</remarks>
		[JsonProperty("downloader.files_downloaded")]
		public long? DownloaderFilesDownloaded { get; set; }

		/// <summary>
		///     This count client activity for mutable files.
		///     'published' is the act of changing an existing mutable file (or creating a brand-new mutable file).
		/// </summary>
		/// <remarks>Only provided by client servers.</remarks>
		[JsonProperty("mutable.bytes_published")]
		public long? MutableBytesPublished { get; set; }

		/// <summary>
		///     This count client activity for mutable files.
		///     'retrieved' is the act of reading its current contents.
		/// </summary>
		/// <remarks>Only provided by client servers.</remarks>
		[JsonProperty("mutable.bytes_retrieved")]
		public long? MutableBytesRetrieved { get; set; }

		/// <summary>
		///     This count client activity for mutable files.
		///     'published' is the act of changing an existing mutable file (or creating a brand-new mutable file).
		/// </summary>
		/// <remarks>Only provided by client servers.</remarks>
		[JsonProperty("mutable.files_published")]
		public long? MutableFilesPublished { get; set; }

		/// <summary>
		///     This count client activity for mutable files.
		///     'retrieved' is the act of reading its current contents.
		/// </summary>
		/// <remarks>Only provided by client servers.</remarks>
		[JsonProperty("mutable.files_retrieved")]
		public long? MutableFilesRetrieved { get; set; }

		/// <summary>
		///     This is for immutable file downloads.
		///     'get' is incremented when a client asks if the server has a specific share.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.get")]
		public int? StorageServerGet { get; set; }

		/// <summary>
		///     This is for immutable file downloads.
		///     'read' is incremented for each chunk of data read.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.read")]
		public int? StorageServerRead { get; set; }

		/// <summary>
		///     This is for immutable file creation, publish, and retrieve.
		///     'readv' is incremented each time a client reads part of a mutable share.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.readv")]
		public int? StorageServerReadv { get; set; }

		/// <summary>
		///     This is for immutable file creation, publish, and retrieve.
		///     'writev' is incremented each time a client sends a modification request.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.writev")]
		public int? StorageServerWritev { get; set; }

		/// <summary>
		///     This is for immutable file uploads.
		///     'allocate' is incremented when a client asks if it can upload a share to the server.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.allocate")]
		public int? StorageServerAllocate { get; set; }

		/// <summary>
		///     This is for immutable file uploads.
		///     'abort' is incremented if the client abandons the upload.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.abort")]
		public int? StorageServerAbort { get; set; }

		/// <summary>
		///     This is for immutable file uploads.
		///     'write' is incremented for each chunk of data written.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.write")]
		public int? StorageServerWrite { get; set; }

		/// <summary>
		///     This is for immutable file uploads.
		///     'close' is incremented when the share is finished.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.close")]
		public int? StorageServerClose { get; set; }

		/// <summary>
		///     This is for share lease modifications.
		///     'add-lease' is incremented when an 'add-lease' operation is performed
		///     (which either adds a new lease or renews an existing lease).
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.add-lease")]
		public int? StorageServerAddLease { get; set; }

		/// <summary>
		///     This is for share lease modifications.
		///     'renew' is for the 'renew-lease' operation (which can only be used to renew an existing one).
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.renew")]
		public int? StorageServerRenew { get; set; }

		/// <summary>
		///     This is for share lease modifications.
		///     'cancel' is used for the 'cancel-lease' operation.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.cancel")]
		public int? StorageServerCancel { get; set; }

		/// <summary>
		///     This counts how many bytes were freed when a 'cancel-lease' operation
		///     removed the last lease from a share and the share was thus deleted.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.bytes_freed")]
		public long? StorageServerBytesFreed { get; set; }

		/// <summary>
		///     This counts how many bytes were consumed by immutable share uploads.
		///     It is incremented at the same time as the 'close' counter.
		/// </summary>
		/// <remarks>Only provided by storage servers.</remarks>
		[JsonProperty("storage_server.bytes_added")]
		public long? StorageServerBytesAdded { get; set; }
	}
}