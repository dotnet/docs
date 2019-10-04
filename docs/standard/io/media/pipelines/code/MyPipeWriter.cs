using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Pipelines;

namespace Pipes
{
    class MyPipeWriter
    {
        #region snippet
        async Task WriteHelloAsync(PipeWriter writer, 
                                   CancellationToken cancellationToken = default)
        {
            // Request at least 5 bytes from the PipeWriter.
            Span<byte> span = writer.GetSpan(5);
            ReadOnlySpan<char> helloSpan = "Hello".AsSpan();

            // Write directly into the buffer.
            int written = Encoding.ASCII.GetBytes(helloSpan, span);

            // Tell the writer how many bytes we wrote.
            writer.Advance(written);

            await writer.FlushAsync(cancellationToken);
        }
        #endregion

        #region snippet2
        async Task WriteHelloAsync2(PipeWriter writer, 
                                    CancellationToken cancellationToken = default)
        {
            byte[] helloBytes = Encoding.ASCII.GetBytes("Hello");

            // Write helloBytes to the writer, there's no need to call Advance here. (Write 
            // does that).
            await writer.WriteAsync(helloBytes, cancellationToken);
        }
        #endregion
    }
}
