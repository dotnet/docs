using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Pipelines;

namespace Pipes
{
    class MyPipeWriter
    {
        // Reverted.  Recommend formatting for table   --------------------------------------
        #region snippet
        async Task WriteHelloAsync(PipeWriter writer, CancellationToken cancellationToken = default)
        {
            // Request at least 5 bytes from the PipeWriter
            Span<byte> span = writer.GetSpan(5);
            ReadOnlySpan<char> helloSpan = "Hello".AsSpan();

            // Write directly into the buffer
            int written = Encoding.ASCII.GetBytes(helloSpan, span);

            // Tell the writer how many bytes we wrote
            writer.Advance(written);

            await writer.FlushAsync(cancellationToken);
        }
        #endregion       
    }

    class MyPipeWriter2
    {
        // Reverted.  Recommend formatting for table   --------------------------------------
        #region snippet2
        async Task WriteHelloAsync(PipeWriter writer, CancellationToken cancellationToken = default)
        {
            byte[] helloBytes = Encoding.ASCII.GetBytes("Hello");

            // Write helloBytes to the writer, there's no need to call Advance here (Write does that)
            await writer.WriteAsync(helloBytes, cancellationToken);
        }
        #endregion
    }
}