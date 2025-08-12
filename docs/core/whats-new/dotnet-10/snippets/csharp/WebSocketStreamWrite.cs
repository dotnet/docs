using System;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

// Writing a single message as a stream (for example, binary serialization)
public async Task SendMessageAsync(AppMessage message, CancellationToken cancellationToken)
{
    using Stream messageStream = WebSocketStream.CreateWritableMessageStream(_connectedWebSocket, WebSocketMessageType.Binary);
    foreach (ReadOnlyMemory<byte> chunk in message.SplitToChunks())
    {
        await messageStream.WriteAsync(chunk, cancellationToken);
    }
} // EOM sent on messageStream.Dispose()