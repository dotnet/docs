open System
open System.IO
open Microsoft.Azure // Namespace for CloudConfigurationManager
open Microsoft.WindowsAzure.Storage // Namespace for CloudStorageAccount
open Microsoft.WindowsAzure.Storage.Blob // Namespace for Blob storage types

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
// Create some local dummy data.
//

// Create a dummy file to upload
let localFile = __SOURCE_DIRECTORY__ + "/myfile.txt"
File.WriteAllText(localFile, "some data")

//
// Create the blob service client.
//

let blobClient = storageAccount.CreateCloudBlobClient()

//
// Create a container.
//

 // Retrieve a reference to a container.
let container = blobClient.GetContainerReference("mydata")

// Create the container if it doesn't already exist.
container.CreateIfNotExists()

let permissions = BlobContainerPermissions(PublicAccess=BlobContainerPublicAccessType.Blob)
container.SetPermissions(permissions)

//
// Upload a blob into a container.
//

// Retrieve reference to a blob named "myblob.txt".
let blockBlob = container.GetBlockBlobReference("myblob.txt")

// Create or overwrite the "myblob.txt" blob with contents from the local file.
do blockBlob.UploadFromFile(localFile)



//
// List the blobs in a container.
//

// Loop over items within the container and output the length and URI.
for item in container.ListBlobs(null, false) do
    match item with 
    | :? CloudBlockBlob as blob -> 
        printfn "Block blob of length %d: %O" blob.Properties.Length blob.Uri

    | :? CloudPageBlob as pageBlob ->
        printfn "Page blob of length %d: %O" pageBlob.Properties.Length pageBlob.Uri

    | :? CloudBlobDirectory as directory ->
        printfn "Directory: %O" directory.Uri

    | _ ->
        printfn "Unknown blob type: %O" (item.GetType())

// Loop over items within the container and output the length and URI.
for item in container.ListBlobs(null, true) do
    match item with 
    | :? CloudBlockBlob as blob -> 
        printfn "Block blob of length %d: %O" blob.Properties.Length blob.Uri

    | _ ->
        printfn "Unexpected blob type: %O" (item.GetType())

//
// Download Blobs.
//

// Retrieve reference to a blob named "myblob.txt".
let blobToDownload = container.GetBlockBlobReference("myblob.txt")

// Save blob contents to a file.
do
    use fileStream = File.OpenWrite(__SOURCE_DIRECTORY__ + "/path/download.txt")
    blobToDownload.DownloadToStream(fileStream)

let text =
    use memoryStream = new MemoryStream()
    blobToDownload.DownloadToStream(memoryStream)
    Text.Encoding.UTF8.GetString(memoryStream.ToArray())

//
// Delete blobs.
//

// Retrieve reference to a blob named "myblob.txt".
let blobToDelete = container.GetBlockBlobReference("myblob.txt")

// Delete the blob.
blobToDelete.Delete()

//
// List blobs in pages asynchronously
//

let ListBlobsSegmentedInFlatListing(container:CloudBlobContainer) =
    async {

        // List blobs to the console window, with paging.
        printfn "List blobs in pages:"

        // Call ListBlobsSegmentedAsync and enumerate the result segment
        // returned, while the continuation token is non-null.
        // When the continuation token is null, the last page has been 
        // returned and execution can exit the loop.

        let rec loop continuationToken (i:int) = 
            async {
                let! ct = Async.CancellationToken
                // This overload allows control of the page size. You can return
                // all remaining results by passing null for the maxResults 
                // parameter, or by calling a different overload.
                let! resultSegment = 
                    container.ListBlobsSegmentedAsync(
                        "", true, BlobListingDetails.All, Nullable 10, 
                        continuationToken, null, null, ct) 
                    |> Async.AwaitTask

                if (resultSegment.Results |> Seq.length > 0) then
                    printfn "Page %d:" i

                for blobItem in resultSegment.Results do
                    printfn "\t%O" blobItem.StorageUri.PrimaryUri

                printfn ""

                // Get the continuation token.
                let continuationToken = resultSegment.ContinuationToken
                if (continuationToken <> null) then
                    do! loop continuationToken (i+1)
            }
    
        do! loop null 1
    }

// Create some dummy data by uploading the same file over and over again
for i in 1 .. 100 do
    let blob  = container.GetBlockBlobReference("myblob" + string i + ".txt")
    use fileStream = System.IO.File.OpenRead(localFile)
    blob.UploadFromFile(localFile)

ListBlobsSegmentedInFlatListing container |> Async.RunSynchronously

//
// Writing to an append blob.
//

// Get a reference to a container.
let appendContainer = blobClient.GetContainerReference("my-append-blobs")

// Create the container if it does not already exist.
appendContainer.CreateIfNotExists() |> ignore

// Get a reference to an append blob.
let appendBlob = appendContainer.GetAppendBlobReference("append-blob.log")

// Create the append blob. Note that if the blob already exists, the 
// CreateOrReplace() method will overwrite it. You can check whether the 
// blob exists to avoid overwriting it by using CloudAppendBlob.Exists().
appendBlob.CreateOrReplace()

let numBlocks = 10

// Generate an array of random bytes.
let rnd = new Random()
let bytes = Array.zeroCreate<byte>(numBlocks)
rnd.NextBytes(bytes)

// Simulate a logging operation by writing text data and byte data to the 
// end of the append blob.
for i in 0 .. numBlocks - 1 do
    let msg = sprintf "Timestamp: %u \tLog Entry: %d\n" DateTime.UtcNow bytes.[i]
    appendBlob.AppendText(msg)

// Read the append blob to the console window.
let downloadedText = appendBlob.DownloadText()
printfn "%s" downloadedText
