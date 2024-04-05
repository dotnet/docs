using System.IO.Compression;
using System.Net;
using System.Net.Sockets;

internal class Program
{
    private static async Task Main()
    {
        // Connect two sockets and wrap a stream around each.
        using (Socket listener = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        using (Socket client = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
            listener.Bind(new IPEndPoint(IPAddress.Loopback, 0));
            listener.Listen(int.MaxValue);
            client.Connect(listener.LocalEndPoint!);
            using (Socket server = listener.Accept())
            {
                var clientStream = new NetworkStream(client, ownsSocket: true);
                var serverStream = new NetworkStream(server, ownsSocket: true);

                // Create some compressed data.
                var compressedData = new MemoryStream();
                using (var gz = new GZipStream(compressedData, CompressionLevel.Fastest, leaveOpen: true))
                {
                    byte[] bytes = new byte[150];
                    new Random().NextBytes(bytes);
                    gz.Write(bytes, 0, bytes.Length);
                }

                // Trickle it from the client stream to the server.
                Task sendTask = Task.Run(() =>
                {
                    foreach (byte b in compressedData.ToArray())
                    {
                        clientStream.WriteByte(b);
                    }
                    clientStream.Dispose();
                });

                // Read and decompress all the sent bytes.
                byte[] buffer = new byte[150];
                int total = 0;
                using (var gz = new GZipStream(serverStream, CompressionMode.Decompress))
                {
                    int numRead = 0;
                    while ((numRead = gz.Read(buffer.AsSpan(numRead))) > 0)
                    {
                        total += numRead;
                        Console.WriteLine($"Read: {numRead} bytes");
                    }
                }
                Console.WriteLine($"Total received: {total} bytes");

                await sendTask;
            }
        }
    }
}
