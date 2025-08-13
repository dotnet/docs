using System.IO;
using System.Net.WebSockets;
using System.Text.Json;

// Reading a single message as a stream (for example, JSON deserialization).
using Stream messageStream = WebSocketStream.CreateReadableMessageStream(connectedWebSocket, WebSocketMessageType.Text);
// JsonSerializer.DeserializeAsync reads until the end of stream.
var appMessage = await JsonSerializer.DeserializeAsync<AppMessage>(messageStream);