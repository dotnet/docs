open System
open System.IO
open Azure.Storage.Files.Shares // Namespace for File storage types
open Azure
open Azure.Storage.Blobs
open Azure.Storage.Sas
open Azure.Storage
open Azure.Storage.Files.Shares.Models

//
// Get your connection string.
//

let storageConnString = "..." // fill this in from your storage account
(*
// Parse the connection string and return a reference to the storage account.
let storageConnString = 
    CloudConfigurationManager.GetSetting("StorageConnectionString")
*)
let shareName = "..." // fill this with the name of the share

//
// Create the File service client.
//

let share = ShareClient(storageConnString, shareName)
share.CreateIfNotExistsAsync()

//
// Create a root directory and a subdirectory
//

// Get a reference to the sample directory
let directory = share.GetDirectoryClient("directoryName")

// Create the directory if it doesn't already exist
directory.CreateIfNotExistsAsync()

//
// Upload a file to the sample directory
//

let file = directory.GetFileClient("fileName")
let stream = File.OpenRead("localFilePath")
file.Create(stream.Length)
file.UploadRange(
    HttpRange(0L, stream.Length),
    stream)

//
// Download a file to a local file
//

let download = file.Download()
let downStream = File.OpenWrite("Save_Download_Path")
download.Value.Content.CopyTo(stream)

//
// Set the maximum size for a file share.
//

// stats.Usage is current usage in GB
let ONE_GIBIBYTE = 10737420000L // Number of bytes in 1 gibibyte
let stats = share.GetStatistics().Value
let currentGiB = (int)(stats.ShareUsageInBytes / ONE_GIBIBYTE)

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
      ShareName = shareName,
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
let sourceFile = ShareFileClient(storageConnString, shareName, "sourceFilePath")
let destFile = ShareFileClient(storageConnString, shareName, "destFilePath")
destFile.StartCopyAsync(sourceFile.Uri)

//
// Copy a file to a blob.
//

// Create a new file SAS 
let fileSAS2 = ShareSasBuilder(
    ShareName = shareName,
    FilePath = "sourceFilePath",
    Resource = "f",
    ExpiresOn = DateTimeOffset.UtcNow.AddHours(24.))
let permissions2 = ShareFileSasPermissions.Read
fileSAS2.SetPermissions(permissions2)
let fileSasUri2 = UriBuilder($"https://{accountName}.file.core.windows.net/{fileSAS.ShareName}/{fileSAS.FilePath}")

// Get a reference to the file we created previously
let sourceFile2 = ShareFileClient(fileSasUri2.Uri)

// Get a reference to the blob to which the file will be copied.
let container = BlobContainerClient(storageConnString, "containerName");
container.CreateIfNotExists()
let destBlob = container.GetBlobClient("blobName")
destBlob.StartCopyFromUriAsync(sourceFile2.Uri)

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
