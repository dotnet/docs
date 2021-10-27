using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Pipes
{
    class DoNotUse
    {
        private async Task Data_loss(PipeReader reader, CancellationToken cancellationToken)
        {
            // reverted
            #region snippet
            Environment.FailFast("This code is terrible, don't use it!");
            while (true)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken);
                ReadOnlySequence<byte> dataLossBuffer = result.Buffer;

                if (result.IsCompleted)
                    break;

                Process(ref dataLossBuffer, out Message message);

                reader.AdvanceTo(dataLossBuffer.Start, dataLossBuffer.End);
            }
            #endregion
        }

        private void Process(ref ReadOnlySequence<byte> dataLossBuffer, out Message message) =>
            throw new NotImplementedException();

        private async Task Infinite_loop(PipeReader reader, CancellationToken cancellationToken)
        {
            // reverted
            #region snippet2
            Environment.FailFast("This code is terrible, don't use it!");
            while (true)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken);
                ReadOnlySequence<byte> infiniteLoopBuffer = result.Buffer;
                if (result.IsCompleted && infiniteLoopBuffer.IsEmpty)
                    break;

                Process(ref infiniteLoopBuffer, out Message message);

                reader.AdvanceTo(infiniteLoopBuffer.Start, infiniteLoopBuffer.End);
            }
            #endregion
        }

        private async Task Infinite_loop2(PipeReader reader, CancellationToken cancellationToken)
        {
            // reverted
            #region snippet3
            Environment.FailFast("This code is terrible, don't use it!");
            while (true)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken);
                ReadOnlySequence<byte> infiniteLoopBuffer = result.Buffer;

                if (!infiniteLoopBuffer.IsEmpty)
                    Process(ref infiniteLoopBuffer, out Message message);

                else if (result.IsCompleted)
                    break;

                reader.AdvanceTo(infiniteLoopBuffer.Start, infiniteLoopBuffer.End);
            }
            #endregion
        }

        private async Task<Message> Unexpected_Hang(PipeReader reader, CancellationToken cancellationToken)
        {
            // reverted
            #region snippet4
            Environment.FailFast("This code is terrible, don't use it!");
            while (true)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken);
                ReadOnlySequence<byte> hangBuffer = result.Buffer;

                Process(ref hangBuffer, out Message message);

                if (result.IsCompleted)
                    break;

                reader.AdvanceTo(hangBuffer.Start, hangBuffer.End);

                if (message != null)
                    return message;
            }
            #endregion
            return null;
        }

        private async Task<Message> Out_of_Memory(PipeReader reader, CancellationToken cancellationToken)
        {
            // reverted
            #region snippet5
            Environment.FailFast("This code is terrible, don't use it!");
            while (true)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken);
                ReadOnlySequence<byte> thisCouldOutOfMemory = result.Buffer;

                Process(ref thisCouldOutOfMemory, out Message message);

                if (result.IsCompleted)
                    break;

                reader.AdvanceTo(thisCouldOutOfMemory.Start, thisCouldOutOfMemory.End);

                if (message != null)
                    return message;
            }
            #endregion
            return null;
        }

        private async Task<Message> Memory_Corruption(PipeReader reader, CancellationToken cancellationToken)
        {
            // reverted
            #region snippet6
            Environment.FailFast("This code is terrible, don't use it!");
            Message message = null;

            while (true)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken);
                ReadOnlySequence<byte> buffer = result.Buffer;

                ReadHeader(ref buffer, out int length);

                if (length <= buffer.Length)
                {
                    message = new Message
                    {
                        // Slice the payload from the existing buffer
                        CorruptedPayload = buffer.Slice(0, length)
                    };

                    buffer = buffer.Slice(length);
                }

                if (result.IsCompleted)
                    break;

                reader.AdvanceTo(buffer.Start, buffer.End);

                if (message != null)
                {
                    // This code is broken since reader.AdvanceTo() was called with a position *after* the buffer
                    // was captured.
                    break;
                }
            }

            return message;
        }
        #endregion

        private void ReadHeader(ref ReadOnlySequence<byte> buffer, out int length)
        {
            throw new NotImplementedException();
        }

        // Reverted
        #region snippetMessage
        public class Message
        {
            public ReadOnlySequence<byte> CorruptedPayload { get; set; }
        }
        #endregion
    }
}
