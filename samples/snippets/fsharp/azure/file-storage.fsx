open System
open System.IO
open Microsoft.Azure // Namespace for CloudConfigurationManager
open Microsoft.WindowsAzure.Storage // Namespace for CloudStorageAccount
open Microsoft.WindowsAzure.Storage.File // Namespace for File storage types

//
// Get your connection string.
//

let storageConnString = "..." // fill this in from your storage account
(*
// Parse the connection string and return a reference to the storage account.
let storageConnString = 
    CloudConfigurationManager.GetSetting("StorageConnectionString")
*)
//
// Parse the connection string.
//

// Parse the connection string and return a reference to the storage account.
let storageAccount = CloudStorageAccount.Parse(storageConnString)

//
// Create the File service client.
//

let fileClient = storageAccount.CreateCloudFileClient()

//
// Create a file share.
//

let share = fileClient.GetShareReference("myfiles")
share.CreateIfNotExists()

//
// Create a root directory and a subdirectory
//

let rootDir = share.GetRootDirectoryReference()
let subDir = rootDir.GetDirectoryReference("myLogs")
subDir.CreateIfNotExists()

//
// Upload a file to a subdirectory
//

let file = subDir.GetFileReference("log.txt")
file.UploadText("This is the content of the log file")

//
// Download a file to a local fie
//

file.DownloadToFile("log.txt", FileMode.Append)

//
// Set the maximum size for a file share.
//

// stats.Usage is current usage in GB
let stats = share.GetStats()
share.FetchAttributes()

// Set the quota to 10 GB plus current usage
share.Properties.Quota <- stats.Usage + 10 |> Nullable
share.SetProperties()

// Remove the quota
share.Properties.Quota <- Nullable()
share.SetProperties()

//
// Generate a shared access signature for a file or file share.
//

// Create a 24-hour read/write policy.
let policy = 
    SharedAccessFilePolicy
       (SharedAccessExpiryTime = (DateTimeOffset.UtcNow.AddHours(24.) |> Nullable),
        Permissions = (SharedAccessFilePermissions.Read ||| SharedAccessFilePermissions.Write))


// Set the policy on the share.
let permissions = share.GetPermissions()
permissions.SharedAccessPolicies.Add("policyName", policy)
share.SetPermissions(permissions)

let sasToken = file.GetSharedAccessSignature(policy)
let sasUri = Uri(file.StorageUri.PrimaryUri.ToString() + sasToken)

let fileSas = CloudFile(sasUri)
fileSas.UploadText("This write operation is authenticated via SAS")

//
// Copy a file to another file.
//

let destFile = subDir.GetFileReference("log_copy.txt")
destFile.StartCopy(file)

//
// Copy a file to a blob.
//

// Get a reference to the blob to which the file will be copied.
let blobClient = storageAccount.CreateCloudBlobClient()
let container = blobClient.GetContainerReference("myContainer")
container.CreateIfNotExists()
let destBlob = container.GetBlockBlobReference("log_blob.txt")

let filePolicy = 
    SharedAccessFilePolicy
        (Permissions = SharedAccessFilePermissions.Read,
         SharedAccessExpiryTime = (DateTimeOffset.UtcNow.AddHours(24.) |> Nullable))

let fileSas2 = file.GetSharedAccessSignature(filePolicy)
let sasUri2 = Uri(file.StorageUri.PrimaryUri.ToString() + fileSas2)
destBlob.StartCopy(sasUri2)

//
// Troubleshooting File storage using metrics.
//

open Microsoft.WindowsAzure.Storage.File.Protocol
open Microsoft.WindowsAzure.Storage.Shared.Protocol

let props =
    FileServiceProperties(
       (HourMetrics = MetricsProperties(
            MetricsLevel = MetricsLevel.ServiceAndApi,
            RetentionDays = (14 |> Nullable),
            Version = "1.0"),
        MinuteMetrics = MetricsProperties(
            MetricsLevel = MetricsLevel.ServiceAndApi,
            RetentionDays = (7 |> Nullable),
            Version = "1.0"))

fileClient.SetServiceProperties(props)
