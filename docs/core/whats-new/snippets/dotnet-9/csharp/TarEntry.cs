using System.Formats.Tar;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace Project;
internal class TarEntry
{
    public static async Task RunItAsync()
    {
        Azure.Storage.Blobs.Models.BlobOpenReadOptions options = new(true);
        CancellationToken cancellationToken = new();
        string connectionString = "";
        string blobContainerName = "";
        string blobName = "";

        // <DataOffset>
        // Create stream for tar ball data in Azure Blob Storage.
        BlobClient blobClient = new(connectionString, blobContainerName, blobName);
        Stream blobClientStream = await blobClient.OpenReadAsync(options, cancellationToken);

        // Create TarReader for the stream and get a TarEntry.
        TarReader tarReader = new(blobClientStream);
        System.Formats.Tar.TarEntry? tarEntry = await tarReader.GetNextEntryAsync();

        if (tarEntry is null)
            return;

        // Get position of TarEntry data in blob stream.
        long entryOffsetInBlobStream = tarEntry.DataOffset;
        long entryLength = tarEntry.Length;

        // Create a separate stream.
        Stream newBlobClientStream = await blobClient.OpenReadAsync(options, cancellationToken);
        newBlobClientStream.Seek(entryOffsetInBlobStream, SeekOrigin.Begin);

        // Read tar ball content from separate BlobClient stream.
        byte[] bytes = new byte[entryLength];
        await newBlobClientStream.ReadExactlyAsync(bytes, 0, (int)entryLength);
        // </DataOffset>
    }
}
