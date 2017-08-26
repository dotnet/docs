using System;
using System.Collections.Generic;

namespace SharedLib
{
	public class FilesListCacheItem
	{
		public IEnumerable<FileInfo> Value { get; set; }
		public DateTime LastUpdateTime { get; set; }

		public FilesListCacheItem()
		{
		}

		public FilesListCacheItem(IEnumerable<FileInfo> value)
		{
			this.Value = value;
			this.LastUpdateTime = DateTime.UtcNow;
		}
	}
}