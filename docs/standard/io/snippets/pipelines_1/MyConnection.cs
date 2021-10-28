using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Threading.Tasks;

namespace Pipes
{
    // Reverted.  Recommend formatting for table   --------------------------------------
    public class MyConnection
    {

        #region snippet
        private PipeReader reader;

        public MyConnection(PipeReader reader)
        {
            this.reader = reader;
        }

        public void Abort()
        {
            // Cancel the pending read so the process loop ends without an exception.
            reader.CancelPendingRead();
        }

        public async Task ProcessMessagesAsync()
        {
            try
            {
                while (true)
                {
                    ReadResult result = await reader.ReadAsync();
                    ReadOnlySequence<byte> buffer = result.Buffer;

                    try
                    {
                        if (result.IsCanceled)
                        {
                            // The read was canceled. You can quit without reading the existing data.
                            break;
                        }

                        // Process all messages from the buffer, modifying the input buffer on each
                        // iteration.
                        while (TryParseLines(ref buffer, out Message message))
                        {
                            await ProcessMessageAsync(message);
                        }

                        // There's no more data to be processed.
                        if (result.IsCompleted)
                        {
                            break;
                        }
                    }
                    finally
                    {
                        // Since all messages in the buffer are being processed, you can use the
                        // remaining buffer's Start and End position to determine consumed and examined.
                        reader.AdvanceTo(buffer.Start, buffer.End);
                    }
                }
            }
            finally
            {
                await reader.CompleteAsync();
            }
        }
        #endregion

        private Task ProcessMessageAsync(Message message)
        {
            throw new NotImplementedException();
        }

        private bool TryParseLines(ref ReadOnlySequence<byte> buffer, out Message message)
        {
            throw new NotImplementedException();
        }
    }
}
