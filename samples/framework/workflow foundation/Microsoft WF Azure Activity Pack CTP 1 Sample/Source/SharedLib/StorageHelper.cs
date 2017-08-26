using System.Configuration;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using System;

namespace SharedLib
{
	public static class StorageHelper
	{
		public const string DefaultStorageConnectionStringName = "Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString";
		public const string FilesContainer = "files";
		public const string FilesTableName = "Files";
		public const string FilesPartitionKey = "DefaultPartition";
		public const string FilesListCacheItemKey = "FilesListCacheItemKey";

		public static string DefaultBlobBaseAddress;

		private static string GetConfigString(string configName)
		{
			return RoleEnvironment.IsAvailable ?
				RoleEnvironment.GetConfigurationSettingValue(configName)
				: ConfigurationManager.AppSettings.Get(configName);
		}

		public static CloudStorageAccount GetCloudStorageAccount()
		{
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(GetConfigString(DefaultStorageConnectionStringName));
			return storageAccount;
		}
	}
}