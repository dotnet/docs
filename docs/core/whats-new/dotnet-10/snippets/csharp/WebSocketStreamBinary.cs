using System;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

// Streaming binary protocol (for example, AMQP).
Stream transportStream = WebSocketStream.Create(
    connectedWebSocket,
    WebSocketMessageType.Binary,
    closeTimeout: TimeSpan.FromSeconds(10));
await message.SerializeToStreamAsync(transportStream, cancellationToken);
var receivePayload = new byte[payloadLength];
await transportStream.ReadExactlyAsync(receivePayload, cancellationToken);
transportStream.Dispose();
// `Dispose` automatically handles closing handshake.