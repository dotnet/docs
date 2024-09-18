using System.IO;
using System.IO.Compression;

namespace Project;
internal class Compression
{
    // <CompressStream>
    private MemoryStream CompressStream(Stream uncompressedStream)
    {
        MemoryStream compressorOutput = new();
        using ZLibStream compressionStream = new(
            compressorOutput,
            new ZLibCompressionOptions()
            {
                CompressionLevel = 6,
                CompressionStrategy = ZLibCompressionStrategy.HuffmanOnly
            }
            );
        uncompressedStream.CopyTo(compressionStream);
        compressionStream.Flush();

        return compressorOutput;
    }
    // </CompressStream>
}
