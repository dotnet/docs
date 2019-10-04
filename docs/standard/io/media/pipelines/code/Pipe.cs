using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Pipes
{
    public class MyPipeSample
    {
        #region snippet
        async Task ProcessLinesAsync(Socket socket)
        {
            var pipe = new Pipe();
            Task writing = FillPipeAsync(socket, pipe.Writer);
            Task reading = ReadPipeAsync(pipe.Reader);

            await Task.WhenAll(reading, writing);
        }

        async Task FillPipeAsync(Socket socket, PipeWriter writer)
        {
            const int minimumBufferSize = 512;

            while (true)
            {
                // Allocate at least 512 bytes from the PipeWriter.
                Memory<byte> memory = writer.GetMemory(minimumBufferSize);
                try
                {
                    int bytesRead = await socket.ReceiveAsync(memory, SocketFlags.None);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    // Tell the PipeWriter how much was read from the Socket.
                    writer.Advance(bytesRead);
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    break;
                }

                // Make the data available to the PipeReader.
                FlushResult result = await writer.FlushAsync();

                if (result.IsCompleted)
                {
                    break;
                }
            }

            // Tell the PipeReader that there's no more data.
            writer.Complete();
        }

        async Task ReadPipeAsync(PipeReader reader)
        {
            while (true)
            {
                ReadResult result = await reader.ReadAsync();
                ReadOnlySequence<byte> buffer = result.Buffer;

                while (TryReadLine(ref buffer, out ReadOnlySequence<byte> line))
                {
                    // Process the line.
                    ProcessLine(line);
                }

                // Tell the PipeReader how much of the buffer has been consumed.
                reader.AdvanceTo(buffer.Start, buffer.End);

                // Stop reading if there's no more data.
                if (result.IsCompleted)
                {
                    break;
                }
            }

            // Mark the PipeReader as complete.
            reader.Complete();
        }

        bool TryReadLine(ref ReadOnlySequence<byte> buffer, 
                         out ReadOnlySequence<byte> bufferOut)
        {
            // Look for a EOL in the buffer.
            SequencePosition? position = buffer.PositionOf((byte)'\n');

            if (position == null)
            {
                buffer = default;
                bufferOut = default;
                return false;
            }

            // Skip the line and the \n
            bufferOut = buffer.Slice(buffer.GetPosition(1, position.Value));
            return true;
        }
        #endregion

// Review Required - Original code below
/*
 *         bool TryReadLine(ref ReadOnlySequence<byte> buffer, out ReadOnlySequence<byte> buffer)
        {
            // Look for a EOL in the buffer.
            SequencePosition? position = buffer.PositionOf((byte)'\n');

            if (position == null)
            {
                buffer = default;
                return false;
            }

            // Skip the line and the \n
            buffer = buffer.Slice(buffer.GetPosition(1, position.Value));
            return true;
        }
        */

        private void ProcessLine(ReadOnlySequence<byte> line)
        {
            throw new NotImplementedException();
        }

        private void dummy()
        {
            #region snippet2
            var pipe = new Pipe();
            PipeReader reader = pipe.Reader;
            PipeWriter writer = pipe.Writer;
            #endregion
        }

        public static void LogError(Exception ex)
        {
            throw new NotImplementedException();
        }

    }
}
 