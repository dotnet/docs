using System;
using System.Collections.Generic;

namespace UIWebRole.Models
{
	public class IndexViewModel
	{
		public IEnumerable<SharedLib.FileInfo> ListInTable { get; set; }
		public IEnumerable<SharedLib.FileInfo> ListInCache { get; set; }
		public DateTime? CacheLastUpdateTime { get; set; }
	}
}