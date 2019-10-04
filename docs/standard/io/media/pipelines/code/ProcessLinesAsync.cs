using System;
using System.Buffers;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Pipes
{
    class MyProcessLinesAsync
    {
        // reverted
        #region snippet
        async Task ProcessLinesAsync(NetworkStream stream)
        {
            byte[] buffer = ArrayPool<byte>.Shared.Rent(1024);
            var bytesBuffered = 0;
            var bytesConsumed = 0;

            while (true)
            {
                // Calculate the amount of bytes remaining in the buffer
                var bytesRemaining = buffer.Length - bytesBuffered;

                if (bytesRemaining == 0)
                {
                    // Double the buffer size and copy the previously buffered data into the new buffer
                    var newBuffer = ArrayPool<byte>.Shared.Rent(buffer.Length * 2);
                    Buffer.BlockCopy(buffer, 0, newBuffer, 0, buffer.Length);
                    // Return the old buffer to the pool
                    ArrayPool<byte>.Shared.Return(buffer);
                    buffer = newBuffer;
                    bytesRemaining = buffer.Length - bytesBuffered;
                }

                var bytesRead = await stream.ReadAsync(buffer, bytesBuffered, bytesRemaining);
                if (bytesRead == 0)
                {
                    // EOF
                    break;
                }

                // Keep track of the amount of buffered bytes
                bytesBuffered += bytesRead;

                do
                {
                    // Look for a EOL in the buffered data
                    linePosition = Array.IndexOf(buffer, (byte)'\n', bytesConsumed, bytesBuffered - bytesConsumed);

                    if (linePosition >= 0)
                    {
                        // Calculate the length of the line based on the offset
                        var lineLength = linePosition - bytesConsumed;

                        // Process the line
                        ProcessLine(buffer, bytesConsumed, lineLength);

                        // Move the bytesConsumed to skip past the line we consumed (including \n)
                        bytesConsumed += lineLength + 1;
                    }
                }
                while (linePosition >= 0);
            }
        }
        #endregion

        private void ProcessLine(byte[] buffer, int bytesConsumed, int lineLength)
        {
            throw new NotImplementedException();
        }
    }
}
