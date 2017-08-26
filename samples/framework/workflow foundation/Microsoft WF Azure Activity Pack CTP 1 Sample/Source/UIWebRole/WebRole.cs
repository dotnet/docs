using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

namespace UIWebRole
{
	public class WebRole : RoleEntryPoint
	{
		public override bool OnStart()
		{
			// For information on handling configuration changes
			// see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

			InitializeAzureStorage();
			return base.OnStart();
		}

		internal static void InitializeAzureStorage()
		{
			var storageAccount = SharedLib.StorageHelper.GetCloudStorageAccount();
			var blobClient = storageAccount.CreateCloudBlobClient();

			var container = blobClient.GetContainerReference(SharedLib.StorageHelper.FilesContainer);
			container.CreateIfNotExist();
			var permissions = container.GetPermissions();
			permissions.PublicAccess = BlobContainerPublicAccessType.Container;
			container.SetPermissions(permissions);

			storageAccount.CreateCloudTableClient().CreateTableIfNotExist(SharedLib.StorageHelper.FilesTableName);
		}
	}
}