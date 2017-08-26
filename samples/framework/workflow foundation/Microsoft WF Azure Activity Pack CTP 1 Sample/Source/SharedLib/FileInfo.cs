using System;

namespace SharedLib
{
	public class FileInfo
	{
		public string Name { get; set; }
		public long Size { get; set; }
		public string ContentType { get; set; }
		public string BlobAddress { get; set; }
		public DateTime UploadTime { get; set; }

		public FileInfo()
		{
		}

		public FileInfo(FileEntity fileEntity)
		{
			this.Name = fileEntity.Name;
			this.Size = fileEntity.Size;
			this.ContentType = fileEntity.ContentType;
			this.BlobAddress = fileEntity.BlobAddress;
			this.UploadTime = fileEntity.Timestamp;
		}
	}
}