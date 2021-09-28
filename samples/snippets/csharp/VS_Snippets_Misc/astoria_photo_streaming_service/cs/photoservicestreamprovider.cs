using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Services;
using System.Data.Services.Providers;
using System.Data.Objects;
using System.Web.Hosting;
using System.Drawing;

namespace PhotoService
{
    class PhotoServiceStreamProvider : IDataServiceStreamProvider, IDisposable
    {
        private string imageFilePath;
        private PhotoInfo cachedEntity;
        private PhotoDataContainer context;

        private string tempFile;

        public PhotoServiceStreamProvider(PhotoDataContainer context)
        {
            this.context = context;

            // Get the physical path to the app_data directory used to store the image files.
            imageFilePath = HostingEnvironment.MapPath("~/App_Data/");

            // Create a temp file to store the new images during POST operations.
            tempFile = Path.GetTempFileName();
        }

        #region IDataServiceStreamProvider Members
        public void DeleteStream(object entity, DataServiceOperationContext operationContext)
        {
            PhotoInfo image = entity as PhotoInfo;
            if (image == null)
            {
                throw new DataServiceException(500, "Internal Server Error.");
            }

            try
            {
                // Delete the requested file by using the key value.
                File.Delete(imageFilePath + "image" + image.PhotoId.ToString());
            }
            catch (IOException ex)
            {
                throw new DataServiceException("The image could not be found.", ex);
            }
        }
        public Stream GetReadStream(object entity, string etag, bool?
            checkETagForEquality, DataServiceOperationContext operationContext)
        {
            if (checkETagForEquality != null)
            {
                // This stream provider implementation does not support
                // ETag headers for media resources. This means that we do not track
                // concurrency for a media resource and last-in wins on updates.
                throw new DataServiceException(400,
                    "This sample service does not support the ETag header for a media resource.");
            }

            PhotoInfo image = entity as PhotoInfo;
            if (image == null)
            {
                throw new DataServiceException(500, "Internal Server Error.");
            }

            // Build the full path to the stored image file, which includes the entity key.
            string fullImageFilePath = imageFilePath + "image" + image.PhotoId;

            if (!File.Exists(fullImageFilePath))
            {
                throw new DataServiceException(500, "The image could not be found.");
            }

            // Return a stream that contains the requested file.
            return new FileStream(fullImageFilePath, FileMode.Open);
        }
        public Uri GetReadStreamUri(object entity, DataServiceOperationContext operationContext)
        {
            // Allow the runtime set the URI of the Media Resource.
            return null;
        }
        public string GetStreamContentType(object entity, DataServiceOperationContext operationContext)
        {
            // Get the PhotoInfo entity instance.
            PhotoInfo image = entity as PhotoInfo;
            if (image == null)
            {
                throw new DataServiceException(500, "Internal Server Error.");
            }

            return image.ContentType;
        }
        public string GetStreamETag(object entity, DataServiceOperationContext operationContext)
        {
            // This sample provider does not support the eTag header with media resources.
            // This means that we do not track concurrency for a media resource
            // and last-in wins on updates.
            return null;
        }
        public Stream GetWriteStream(object entity, string etag, bool?
            checkETagForEquality, DataServiceOperationContext operationContext)
        {
            if (checkETagForEquality != null)
            {
                // This stream provider implementation does not support ETags associated with BLOBs.
                // This means that we do not track concurrency for a media resource
                // and last-in wins on updates.
                throw new DataServiceException(400,
                    "This demo does not support ETags associated with BLOBs");
            }

            PhotoInfo image = entity as PhotoInfo;

            if (image == null)
            {
                throw new DataServiceException(500, "Internal Server Error: "
                + "the Media Link Entry could not be determined.");
            }

            // Handle the POST request.
            if (operationContext.RequestMethod == "POST")
            {
                // Set the file name from the Slug header; if we don't have a
                // Slug header, just set a temporary name which is overwritten
                // by the subsequent MERGE request from the client.
                image.FileName = operationContext.RequestHeaders["Slug"] ?? "newFile";

                // Set the required DateTime values.
                image.DateModified = DateTime.Today;
                image.DateAdded = DateTime.Today;

                // Set the content type, which cannot be null.
                image.ContentType = operationContext.RequestHeaders["Content-Type"];

                // Cache the current entity to enable us to both create a key based storage file name
                // and to maintain transactional integrity in the disposer; we do this only for a POST request.
                cachedEntity = image;

                return new FileStream(tempFile, FileMode.Open);
            }
            // Handle the PUT request
            else
            {
                // Return a stream to write to an existing file.
                return new FileStream(imageFilePath + "image" + image.PhotoId.ToString(),
                    FileMode.Open, FileAccess.Write);
            }
        }
        public string ResolveType(string entitySetName, DataServiceOperationContext operationContext)
        {
            // We should only be handling PhotoInfo types.
            if (entitySetName == "PhotoInfo")
            {
                return "PhotoService.PhotoInfo";
            }
            else
            {
                // This will raise an DataServiceException.
                return null;
            }
        }
        public int StreamBufferSize
        {
            // Use a buffer size of 64K bytes.
            get { return 64000; }
        }
        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            // If we have a cached entity, it must be a POST request.
            if (cachedEntity != null)
            {
                string newImageFileName = imageFilePath + "image" + cachedEntity.PhotoId.ToString();
                string newImageThumbnailName =
                    imageFilePath + "image" + cachedEntity.PhotoId.ToString() + "_thumb";

                // Get the new entity from the Entity Framework object state manager.
                ObjectStateEntry entry = this.context.ObjectStateManager.GetObjectStateEntry(cachedEntity);

                if (entry.State == System.Data.EntityState.Unchanged)
                {
                    // Since the entity was created successfully, move the temp file into the
                    // storage directory and rename the file based on the new entity key.
                    File.Move(tempFile, newImageFileName);

                    // Delete the temp file.
                    File.Delete(tempFile);

                    // Create a bitmap for the new image.
                    Bitmap newImage = new Bitmap(newImageFileName);

                    // Generate the 100px thumbnail of the image.
                    Image thumbnail = newImage.GetThumbnailImage(100, 100, null, IntPtr.Zero);

                    // Save the thumbnail.
                    thumbnail.Save(newImageThumbnailName);
                }
                else
                {
                    // A problem must have occurred when saving the entity to the database,
                    // so we should delete the entity and temp file.
                    context.DeleteObject(cachedEntity);
                    File.Delete(tempFile);

                    throw new DataServiceException("An error occurred. The photo could not be saved.");
                }
            }
        }
        #endregion

    }
}
