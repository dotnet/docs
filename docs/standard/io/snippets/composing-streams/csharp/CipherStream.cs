using System.IO;

public class CipherStream : Stream
{
    // WARNING: This is a simple encoding algorithm and should not be used in production code

    const byte ENCODING_OFFSET = 80;

    private bool _readable;
    private bool _writable;

    private Stream _wrappedBaseStream;

    public override bool CanRead => _readable;
    public override bool CanSeek => false;
    public override bool CanWrite => _writable;
    public override long Length => _wrappedBaseStream.Length;
    public override long Position
    {
        get => _wrappedBaseStream.Position;
        set => _wrappedBaseStream.Position = value;
    }

    public static CipherStream CreateForRead(Stream stream)
    {
        CipherStream cipherStream = new CipherStream(stream)
        {
            _readable = true,
            _writable = false
        };

        return cipherStream;
    }

    public static CipherStream CreateForWrite(Stream stream)
    {
        CipherStream cipherStream = new CipherStream(stream)
        {
            _readable = false,
            _writable = true
        };

        return cipherStream;
    }

    private CipherStream(Stream stream) =>
        _wrappedBaseStream = stream;

    public override int Read(byte[] buffer, int offset, int count)
    {
        if (!_readable) throw new NotSupportedException();
        if (count == 0) return 0;

        for (int i = 0; i < count; i++)
        {
            int value = _wrappedBaseStream.ReadByte();

            if (value == -1)
                return 0;

            value += ENCODING_OFFSET;
            if (value > byte.MaxValue)
                value = value - byte.MaxValue;

            buffer[i + offset] = Convert.ToByte(value);
        }

        return count;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        if (!_writable) throw new NotSupportedException();

        byte[] newBuffer = new byte[count];
        buffer.CopyTo(newBuffer, offset);

        for (int i = 0; i < count; i++)
        {
            int value = newBuffer[i];

            value -= ENCODING_OFFSET;

            if (value < 0)
                value = byte.MaxValue - value;

            newBuffer[i] = Convert.ToByte(value);
        }

        _wrappedBaseStream.Write(newBuffer, 0, count);
    }

    public override void Flush() => _wrappedBaseStream.Flush();
    public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
    public override void SetLength(long value) => throw new NotSupportedException();
}
