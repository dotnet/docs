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

        #region snippet3
        long FindIndexOf(in ReadOnlySequence<byte> buffer, byte data)
        {
            long position = 0;

            foreach (ReadOnlyMemory<byte> segment in buffer)
            {
                ReadOnlySpan<byte> span = segment.Span;
                var index = span.IndexOf(data);
                if (index != -1)
                {
                    return position + index;
                }

                position += span.Length;
            }

            return -1;
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

        #region snippet4
        SequencePosition? FindIndexOf(in ReadOnlySequence<byte> buffer, byte data)
        {
            SequencePosition position = buffer.Start;

            while (buffer.TryGet(ref position, out ReadOnlyMemory<byte> segment))
            {
                ReadOnlySpan<byte> span = segment.Span;
                var index = span.IndexOf(data);
                if (index != -1)
                {
                    return buffer.GetPosition(position, index);
                }
            }
            return null;
        }
        #endregion
    }
}
