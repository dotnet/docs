open System
open System.IO
open Azure.Storage.Blobs // Namespace for Blob storage types
open Azure.Storage.Blobs.Models
open Azure.Storage.Blobs.Specialized
open System.Text

//
// Switch to the source directory that this is used implicitly when interacting with the File object.
//

System.Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

//
// Get your connection string.
//

let storageConnString = "..." // fill this in from your storage account

//
// Create some local dummy data.
//

// Create a dummy file to upload
let localFile = "./myfile.txt"
File.WriteAllText(localFile, "some data")

//
// Create a container.
//

 // Create a blob container client.
let container = BlobContainerClient(storageConnString, "myContainer")

// Create the container if it doesn't already exist.
container.CreateIfNotExists()

let permissions = PublicAccessType.Blob
container.SetAccessPolicy(permissions)

//
// Upload a blob into a container.
//

// Retrieve reference to a blob named "myblob.txt".
let blockBlob = container.GetBlobClient("myblob.txt")

// Create or overwrite the "myblob.txt" blob with contents from the local file.
use fileStream = new FileStream(localFile, FileMode.Open, FileAccess.Read, FileShare.Read)
do blockBlob.Upload(fileStream)

//
// List the blobs in a container.
//

// Loop over items within the container and output the name.
for item in container.GetBlobsByHierarchy() do
    printfn $"Blob name: {item.Blob.Name}"

//
// Download Blobs.
//

// Retrieve reference to a blob named "myblob.txt".
let blobToDownload = container.GetBlobClient("myblob.txt")

// Save blob contents to a file.
do
    use fileStream = File.OpenWrite("path/download.txt")
    blobToDownload.DownloadTo(fileStream)

let text = blobToDownload.DownloadContent().Value.Content.ToString()

//
// Delete blobs.
//

// Retrieve reference to a blob named "myblob.txt".
let blobToDelete = container.GetBlobClient("myblob.txt")

// Delete the blob.
blobToDelete.Delete()

//
// List blobs in pages asynchronously
//

let ListBlobsSegmentedInHierarchicalListing(container:BlobContainerClient) =
        // List blobs to the console window, with paging.
        printfn "List blobs in pages:"

        // Call GetBlobsByHierarchy to return an async collection 
        // of blobs in this container. AsPages() method enumerate the values 
        //a Page<T> at a time. This may make multiple service requests.

        for page in container.GetBlobsByHierarchy().AsPages() do
            for blobHierarchyItem in page.Values do 
                printf $"The BlobItem is : {blobHierarchyItem.Blob.Name} "

        printfn ""


// Create some dummy data by uploading the same file over and over again
for i in 1 .. 100 do
    let blob  = container.GetBlobClient($"myblob{i}.txt")
    use fileStream = System.IO.File.OpenRead(localFile)
    blob.Upload(localFile)

ListBlobsSegmentedInHierarchicalListing container

//
// Writing to an append blob.
//

// Get a reference to a container.
let appendContainer = BlobContainerClient(storageConnString, "my-append-blobs")

// Create the container if it does not already exist.
appendContainer.CreateIfNotExists() |> ignore

// Get a reference to an append blob.
let appendBlob = appendContainer.GetAppendBlobClient("append-blob.log")

// Create the append blob. Note that if the blob already exists, the 
// CreateOrReplace() method will overwrite it. You can check whether the 
// blob exists to avoid overwriting it by using CloudAppendBlob.Exists().
appendBlob.CreateIfNotExists()

let numBlocks = 10

// Generate an array of random bytes.
let rnd = Random()
let bytesArray = Array.zeroCreate<byte>(numBlocks)
rnd.NextBytes(bytesArray)

// Simulate a logging operation by writing text data and byte data to the 
// end of the append blob.
for i in 0 .. numBlocks - 1 do
    let msg = sprintf $"Timestamp: {DateTime.UtcNow} \tLog Entry: {bytesArray.[i]}\n"
    let array = Encoding.ASCII.GetBytes(msg);
    use stream = new MemoryStream(array)
    appendBlob.AppendBlock(stream)

// Read the append blob to the console window.
let downloadedText = appendBlob.DownloadContent().ToString()
printfn $"{downloadedText}"
