using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Fluent;

namespace Project;
internal class TarEntry
{
    public static async Task RunItAsync()
    {
        Azure.Storage.Blobs.Models.BlobOpenReadOptions options = new();
        CancellationToken cancellationToken = new();

        // <DataOffset>
        // Create stream for tar ball data in Azure Blob Storage.
        var blobClient = Azure.Storage.Blobs.BlobClient();
        var blobClientStream = await blobClient.OpenReadAsync(options, cancellationToken);

        // Create TarReader for the stream and get a TarEntry.
        var tarReader = new System.Formats.Tar.TarReader(blobClientStream);
        var tarEntry = await tarReader.GetNextEntryAsync();

        // Get position of TarEntry data in blob stream.
        var entryOffsetInBlobStream = tarEntry.DataOffset;
        var entryLength = tarEntry.Length;

        // Create a separate stream.
        var newBlobClientStream = await blobClient.OpenReadAsync(options, cancellationToken);
        newBlobClientStream.Seek(entryOffsetInBlobStream, SeekOrigin.Begin);

        // Read tar ball content from separate BlobClient stream.
        var bytes = new byte[length];
        await newBlobClientStream.ReadAsync(bytes, 0, (int)entryLength);
        // </DataOffset>
    }
}
