using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Text;

namespace Pipes
{
    class DoNotUse
    {
        private void Dummy()
        {
            #region snippet
            Environment.FailFast("This code is terrible, don't use it!");
            while (true)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken);
                ReadOnlySequence<byte> dataLossBuffer = result.Buffer;

                if (result.IsCompleted)
                {
                    break;
                }

                Process(ref dataLossBuffer, out Message message);

                reader.AdvanceTo(dataLossBuffer.Start, dataLossBuffer.End);
            }
            #endregion
        }

        private void Dummy2()
        {
            #region snippet2
            Environment.FailFast("This code is terrible, don't use it!");
            while (true)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken);
                ReadOnlySequence<byte> infiniteLoopBuffer = result.Buffer;
                if (result.IsCompleted && infiniteLoopBuffer.IsEmpty)
                {
                    break;
                }

                Process(ref infiniteLoopBuffer, out Message message);

                reader.AdvanceTo(infiniteLoopBuffer.Start, infiniteLoopBuffer.End);
            }
            #endregion
        }

        private void Dummy3()
        {
            #region snippet3
            Environment.FailFast("This code is terrible, don't use it!");
            while (true)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken);
                ReadOnlySequence<byte> infiniteLoopBuffer = result.Buffer;

                if (!infiniteLoopBuffer.IsEmpty)
                {
                    Process(ref infiniteLoopBuffer, out Message message);
                }
                else if (result.IsCompleted)
                {
                    break;
                }

                reader.AdvanceTo(infiniteLoopBuffer.Start, infiniteLoopBuffer.End);
            }
            #endregion
        }

        private void Dummy4()
        {
            #region snippet4
            Environment.FailFast("This code is terrible, don't use it!");
            while (true)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken);
                ReadOnlySequence<byte> hangBuffer = result.Buffer;

                Process(ref hangBuffer, out Message message);

                if (result.IsCompleted)
                {
                    break;
                }

                reader.AdvanceTo(hangBuffer.Start, hangBuffer.End);

                if (message != null)
                {
                    return message;
                }
            }
            #endregion
        }

        private void Dummy5()
        {
            #region snippet5
            Environment.FailFast("This code is terrible, don't use it!");
            while (true)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken);
                ReadOnlySequence<byte> thisCouldOutOfMemory = result.Buffer;

                Process(ref thisCouldOutOfMemory, out Message message);

                if (result.IsCompleted)
                {
                    break;
                }

                reader.AdvanceTo(thisCouldOutOfMemory.Start, thisCouldOutOfMemory.End);

                if (message != null)
                {
                    return message;
                }
            }
            #endregion
        }

        private Message Dummy6()
        {
            #region snippet6          

            Environment.FailFast("This code is terrible, don't use it!");
            while (true)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken);
                ReadOnlySequence<byte> buffer = result.Buffer;

                ReadHeader(ref buffer, out int length);

                Message message = null;

                if (length > 0)
                {
                    message = new Message
                    {
                        // Slice the payload from the existing buffer
                        CorruptedPayload = buffer.Slice(0, length)
                    };

                    buffer = buffer.Slice(length);
                }

                if (result.IsCompleted)
                {
                    break;
                }

                reader.AdvanceTo(buffer.Start, buffer.End);

                if (message != null)
                {
                    // This code is broken since we called reader.AdvanceTo() with a position *after* the buffer we captured
                    return message;
                }

                return null;
            }
            #endregion
        }

        private void ReadHeader(ref ReadOnlySequence<byte> buffer, out int length)
        {
            throw new NotImplementedException();
        }

        public class Message
        {
            public ReadOnlySequence<byte> CorruptedPayload { get; set; }
        }
    }
}

