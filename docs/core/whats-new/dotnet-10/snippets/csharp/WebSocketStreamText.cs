using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

// Streaming text protocol (for example, STOMP).
using Stream transportStream = WebSocketStream.Create(
    connectedWebSocket, 
    WebSocketMessageType.Text,
    ownsWebSocket: true);
// Integration with Stream-based APIs.
// Don't close the stream, as it's also used for writing.
using var transportReader = new StreamReader(transportStream, leaveOpen: true); 
var line = await transportReader.ReadLineAsync(cancellationToken); // Automatic UTF-8 and new line handling.
transportStream.Dispose(); // Automatic closing handshake handling on `Dispose`.