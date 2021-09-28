open System
open System.IO
open Azure
open Azure.Storage // Namespace for StorageSharedKeyCredential
open Azure.Storage.Blobs // Namespace for BlobContainerClient
open Azure.Storage.Sas // Namespace for ShareSasBuilder
open Azure.Storage.Files.Shares // Namespace for File storage types
open Azure.Storage.Files.Shares.Models // Namespace for ShareServiceProperties

//
// Get your connection string.
//

let storageConnString = "..." // fill this in from your storage account

//
// Create the File service client.
//

let share = ShareClient(storageConnString, "shareName")

//
// Create a file share.
//

share.CreateIfNotExistsAsync()

//
// Create a directory
//

// Get a reference to the directory
let directory = share.GetDirectoryClient("directoryName")

// Create the directory if it doesn't already exist
directory.CreateIfNotExistsAsync()

//
// Upload a file to the sample directory
//

let file = directory.GetFileClient("fileName")

let writeToFile localFilePath = 
    use stream = File.OpenRead(localFilePath)
    file.Create(stream.Length)
    file.UploadRange(
        HttpRange(0L, stream.Length),
        stream)

writeToFile "localFilePath"

//
// Download a file to a local file
//

let download = file.Download()

let copyTo saveDownloadPath = 
    use downStream = File.OpenWrite(saveDownloadPath)
    download.Value.Content.CopyTo(downStream)

copyTo "Save_Download_Path"

//
// Set the maximum size for a file share.
//

// stats.Usage is current usage in GB
let ONE_GIBIBYTE = 10_737_420_000L // Number of bytes in 1 gibibyte
let stats = share.GetStatistics().Value
let currentGiB = int (stats.ShareUsageInBytes / ONE_GIBIBYTE)

// Set the quota to 10 GB plus current usage
share.SetQuotaAsync(currentGiB + 10)

// Remove the quota
share.SetQuotaAsync(0)

//
// Generate a shared access signature for a file or file share.
//

let accountName = "..." // Input your storage account name
let accountKey = "..." // Input your storage account key

// Create a 24-hour read/write policy.
let expiration = DateTimeOffset.UtcNow.AddHours(24.)
let fileSAS = ShareSasBuilder(
      ShareName = "shareName",
      FilePath = "filePath",
      Resource = "f",
      ExpiresOn = expiration)

// Set the permissions for the SAS
let permissions = ShareFileSasPermissions.All
fileSAS.SetPermissions(permissions)

// Create a SharedKeyCredential that we can use to sign the SAS token
let credential = StorageSharedKeyCredential(accountName, accountKey)

// Build a SAS URI
let fileSasUri = UriBuilder($"https://{accountName}.file.core.windows.net/{fileSAS.ShareName}/{fileSAS.FilePath}")
fileSasUri.Query = fileSAS.ToSasQueryParameters(credential).ToString()

//
// Copy a file to another file.
//
let sourceFile = ShareFileClient(storageConnString, "shareName", "sourceFilePath")
let destFile = ShareFileClient(storageConnString, "shareName", "destFilePath")
destFile.StartCopyAsync(sourceFile.Uri)

//
// Copy a file to a blob.
//

// Create a new file SAS 
let fileSASCopyToBlob = ShareSasBuilder(
    ShareName = "shareName",
    FilePath = "sourceFilePath",
    Resource = "f",
    ExpiresOn = DateTimeOffset.UtcNow.AddHours(24.))
let permissionsCopyToBlob = ShareFileSasPermissions.Read
fileSASCopyToBlob.SetPermissions(permissionsCopyToBlob)
let fileSasUriCopyToBlob = UriBuilder($"https://{accountName}.file.core.windows.net/{fileSASCopyToBlob.ShareName}/{fileSASCopyToBlob.FilePath}")

// Get a reference to the file.
let sourceFileCopyToBlob = ShareFileClient(fileSasUriCopyToBlob.Uri)

// Get a reference to the blob to which the file will be copied.
let containerCopyToBlob = BlobContainerClient(storageConnString, "containerName");
containerCopyToBlob.CreateIfNotExists()
let destBlob = containerCopyToBlob.GetBlobClient("blobName")
destBlob.StartCopyFromUriAsync(sourceFileCopyToBlob.Uri)

//
// Troubleshooting File storage using metrics.
//

// Instatiate a ShareServiceClient
let shareService = ShareServiceClient(storageConnString);

// Set metrics properties for File service
let props = ShareServiceProperties()

props.HourMetrics = ShareMetrics(
    Enabled = true,
    IncludeApis = true,
    Version = "1.0",
    RetentionPolicy = ShareRetentionPolicy(Enabled = true,Days = 14))

props.MinuteMetrics = ShareMetrics(
    Enabled = true,
    IncludeApis = true,
    Version = "1.0",
    RetentionPolicy = ShareRetentionPolicy(Enabled = true,Days = 7))

shareService.SetPropertiesAsync(props)
