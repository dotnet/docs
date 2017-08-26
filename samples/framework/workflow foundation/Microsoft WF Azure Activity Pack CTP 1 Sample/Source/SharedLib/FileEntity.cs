using System;
using Microsoft.WindowsAzure.StorageClient;

namespace SharedLib
{
	public class FileEntity : TableServiceEntity
	{
		public string Name { get; set; }
		public long Size { get; set; }
		public string ContentType { get; set; }
		public string BlobAddress { get; set; }

		public FileEntity()
		{
		}

		public FileEntity(FileInfo fileInfo)
		{
			this.PartitionKey = StorageHelper.FilesPartitionKey;
			this.RowKey = Guid.NewGuid().ToString();
			this.Name = fileInfo.Name;
			this.Size = fileInfo.Size;
			this.ContentType = fileInfo.ContentType;
			this.BlobAddress = fileInfo.BlobAddress;
		}
	}
}