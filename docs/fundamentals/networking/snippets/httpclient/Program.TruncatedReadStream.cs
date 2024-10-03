static partial class Program
{
    static async Task TruncatedReadStream()
    {
        // <TruncatedReadStreamUsage>
        int maxErrorResponseLength = 1 * 1024; // 1 KB

        HttpClient client = new HttpClient();
        using HttpResponseMessage response = await client.GetAsync(Uri);

        if (response.Content is not null)
        {
            Stream responseReadStream = await response.Content.ReadAsStreamAsync();
            // If MaxErrorResponseLength is set and the response status code is an error code, then wrap the response stream in a TruncatedReadStream
            if (maxErrorResponseLength >= 0 && !response.IsSuccessStatusCode)
            {
                responseReadStream = new TruncatedReadStream(responseReadStream, maxErrorResponseLength);
            }
            // Read the response stream
            Memory<byte> buffer = new byte[1024];
            int readValue = await responseReadStream.ReadAsync(buffer);
        }
        // </TruncatedReadStreamUsage>
    }
}

// <TruncatedReadStream>
internal sealed class TruncatedReadStream(Stream innerStream, long maxSize) : Stream
{
    private long _maxRemainingLength = maxSize;
    public override bool CanRead => true;
    public override bool CanSeek => false;
    public override bool CanWrite => false;

    public override long Length => throw new NotSupportedException();
    public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }

    public override void Flush() => throw new NotSupportedException();

    public override int Read(byte[] buffer, int offset, int count)
    {
        return Read(new Span<byte>(buffer, offset, count));
    }

    public override int Read(Span<byte> buffer)
    {
        int readBytes = innerStream.Read(buffer.Slice(0, (int)Math.Min(buffer.Length, _maxRemainingLength)));
        _maxRemainingLength -= readBytes;
        return readBytes;
    }

    public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        return ReadAsync(new Memory<byte>(buffer, offset, count), cancellationToken).AsTask();
    }

    public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
    {
        int readBytes = await innerStream.ReadAsync(buffer.Slice(0, (int)Math.Min(buffer.Length, _maxRemainingLength)), cancellationToken)
            .ConfigureAwait(false);
        _maxRemainingLength -= readBytes;
        return readBytes;
    }

    public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
    public override void SetLength(long value) => throw new NotSupportedException();
    public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

    public override ValueTask DisposeAsync() => innerStream.DisposeAsync();

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            innerStream.Dispose();
        }
    }
}
// </TruncatedReadStream>
