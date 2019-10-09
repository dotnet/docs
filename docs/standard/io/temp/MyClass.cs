using System;
using System.Buffers;
using System.Text;

namespace MyBuffers
{
    class MyClass
    {
        #region snippet
        void WriteHello(IBufferWriter<byte> writer)
        {
            // Request at least 5 bytes.
            Span<byte> span = writer.GetSpan(5);
            ReadOnlySpan<char> helloSpan = "Hello".AsSpan();
            int written = Encoding.ASCII.GetBytes(helloSpan, span);

            // Tell the writer how many bytes were written.
            writer.Advance(written);
        }
        #endregion
    }

    class MyClass2
    {
        #region snippet2
        void WriteHello(IBufferWriter<byte> writer)
        {
            byte[] helloBytes = Encoding.ASCII.GetBytes("Hello");

            // Write helloBytes to the writer, there's no need to call Advance here.
            // Write calls Advance.
            writer.Write(helloBytes);
        }
        #endregion
    }
}
