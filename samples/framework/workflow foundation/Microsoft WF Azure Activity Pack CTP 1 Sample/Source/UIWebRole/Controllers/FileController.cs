using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ApplicationServer.Caching;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using SharedLib;

namespace UIWebRole.Controllers
{
	public class FileController : AsyncController
	{
		private static CloudStorageAccount StorageAccount = SharedLib.StorageHelper.GetCloudStorageAccount();

		private static DataCache DataCacheClient = new DataCacheFactory().GetDefaultCache();

		public FileController()
		{
		}

		public ViewResult Index()
		{
			Models.IndexViewModel model = new Models.IndexViewModel();

			var ctx = StorageAccount.CreateCloudTableClient().GetDataServiceContext();
			var query = ctx.CreateQuery<FileEntity>(StorageHelper.FilesTableName).AsTableServiceQuery();
			IEnumerable<SharedLib.FileInfo> listInTable = query.Execute().Select(e => new SharedLib.FileInfo()
				{
					Name = e.Name,
					Size = e.Size,
					ContentType = e.ContentType,
					BlobAddress = e.BlobAddress,
					UploadTime = e.Timestamp
				}) as IEnumerable<SharedLib.FileInfo>;
			if (listInTable != null && 0 < listInTable.Count())
			{
				listInTable = listInTable.OrderByDescending(e => e.UploadTime);
			}
			model.ListInTable = listInTable;

			SharedLib.FilesListCacheItem filesListCacheItem = DataCacheClient.Get(SharedLib.StorageHelper.FilesListCacheItemKey) as SharedLib.FilesListCacheItem;
			if (filesListCacheItem != null)
			{
				IEnumerable<SharedLib.FileInfo> listInCache = filesListCacheItem.Value as IEnumerable<SharedLib.FileInfo>;
				if (listInCache != null && 0 < listInCache.Count())
				{
					listInCache = listInCache.OrderByDescending(e => e.UploadTime);
				}
				model.ListInCache = listInCache;
				model.CacheLastUpdateTime = filesListCacheItem.LastUpdateTime;
			}

			return View(model);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public void CreateAsync(HttpPostedFileBase file)
		{
			if (ModelState.IsValid && file != null)
			{
				SharedLib.FileInfo fileInfo = new SharedLib.FileInfo()
				{
					Name = file.FileName.Substring(file.FileName.LastIndexOf('\\') + 1),
					ContentType = file.ContentType,
					Size = file.InputStream.Length,
					BlobAddress = string.Format("{0}/{1}", SharedLib.StorageHelper.FilesContainer, Guid.NewGuid().ToString())
				};

				StorageAccount.CreateCloudBlobClient().GetBlobReference(fileInfo.BlobAddress).UploadFromStream(file.InputStream);

				AsyncManager.OutstandingOperations.Increment();

				var fileService = new FileServiceReference.ServiceClient();
				fileService.StoreFileEntityAsync(fileInfo);
				fileService.StoreFileEntityCompleted += (sender, args) =>
				{
					AsyncManager.Parameters["isSuccessful"] = args.Result;
					AsyncManager.Parameters["errorMessage"] = args.ErrorMessage;
					AsyncManager.OutstandingOperations.Decrement();
				};
			}
		}

		[HttpPost]
		public ActionResult CreateCompleted(bool ErrorMessage, FileEntity fileEntity, string errorMessage)
		{
			return RedirectToAction("Index");
		}
	}
}