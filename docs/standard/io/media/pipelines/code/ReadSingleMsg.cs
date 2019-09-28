using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Pipes
{
    class ReadSingleMsg
    {
        #region snippet
        async ValueTask<Message> ReadSingleMessageAsync(PipeReader reader, 
                                                CancellationToken cancellationToken = default)
        {
            while (true)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken);
                ReadOnlySequence<byte> buffer = result.Buffer;

                // In the event no message is parsed successfully,
                // mark consumed as nothing and examined as the entire buffer.
                SequencePosition consumed = buffer.Start;
                SequencePosition examined = buffer.End;

                try
                {
                    if (TryParseMessage(ref buffer, out Message message))
                    {
                        // Successfully parsed a single message so mark the start
                        // as the parsed buffer as consumed.
                        // TryParseMessage trims the buffer to point to the data
                        // after the message is parsed.
                        consumed = buffer.Start;

                        // Examined is marked the same as consumed here so that the
                        // next call to ReadSingleMessageAsync processs the next message
                        // if there is one
                        examined = consumed;

                        return message;
                    }

                    // There's no more data to be processed.
                    if (result.IsCompleted)
                    {
                        if (buffer.Length > 0)
                        {
                            // There is an incomplete message and there's no more data
                            // to process.
                            throw new InvalidDataException("Incomplete message!");
                        }

                        break;
                    }
                }
                finally
                {
                    reader.AdvanceTo(consumed, examined);
                }
            }

            return null;
        }
        #endregion

    }
}
