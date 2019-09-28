using System;
using System.Buffers;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Pipes
{
    class MyConnection1
    {
        #region snippet
        async Task ProcessMessagesAsync(PipeReader reader, 
                                        CancellationToken cancellationToken = default)
        {
            try
            {
                while (true)
                {
                    ReadResult result = await reader.ReadAsync(cancellationToken);
                    ReadOnlySequence<byte> buffer = result.Buffer;

                    try
                    {
                        // Process all messages from the buffer, modifying the input buffer
                        // on each iteration.
                        while (TryParseMessage(ref buffer, out Message message))
                        {
                            await ProcessMessageAsync(message);
                        }

                        // There's no more data to be processed
                        if (result.IsCompleted)
                        {
                            if (buffer.Length > 0)
                            {
                                // We have an incomplete message and there's no more data to
                                // process.
                                throw new InvalidDataException("Incomplete message!");
                            }
                            break;
                        }
                    }
                    finally
                    {
                        // Since we're processing all messages in the buffer, we can use the
                        // remaining buffer'sStart and End position to determine consumed and 
                        // examined.
                        reader.AdvanceTo(buffer.Start, buffer.End);
                    }
                }
            }
            finally
            {
                await reader.CompleteAsync();
            }
        }

        private Task ProcessMessageAsync(Message message)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
