using System.Text;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class Utf8ReaderPartialRead
    {
        public static void Run()
        {

            var jsonString = """
            {
                "Date": "2019-08-01T00:00:00-07:00",
                "Temperature": 25,
                "TemperatureRanges": {
                    "Cold": { "High": 20, "Low": -10 },
                    "Hot": { "High": 60, "Low": 20 }
                },
                "Summary": "Hot"
            }
            """u8;

            // Buffer size wouldn't typically be this small
            // Using a small size to demonstrate refilling buffer given small payload
            const int SIZE = 64;
            var searchText = "Summary"u8;
            var foundTerm = false;
            var stream = new MemoryStream(jsonString.ToArray());
            Span<byte> buffer = new byte[SIZE];
            int read = stream.Read(buffer);

            var reader = new Utf8JsonReader(buffer[0..read], isFinalBlock: read < SIZE, state: default);
            Console.WriteLine($"String in buffer is: {Encoding.UTF8.GetString(buffer[..read])}");

            // Search for "Summary" property name
            while (reader.Read() || UpdateBuffer(stream, ref buffer, ref read, ref reader))
            {
                if (reader.TokenType is JsonTokenType.PropertyName && reader.ValueTextEquals(searchText))
                {
                    foundTerm = true;
                }
                else if (foundTerm && reader.TokenType is JsonTokenType.String)
                {
                    Console.WriteLine($"Found {Encoding.UTF8.GetString(searchText)} value: {reader.GetString()}");
                    break;
                }
            }

            Console.WriteLine($"String in buffer is: {Encoding.UTF8.GetString(buffer[..read])}");

            static bool UpdateBuffer(MemoryStream stream, ref Span<byte> buffer, ref int read, ref Utf8JsonReader reader)
            {
                var bytesConsumed = (int)reader.BytesConsumed;
                var bufferStart = 0;

                if (bytesConsumed < buffer.Length)
                {
                    var leftOver = buffer[bytesConsumed..];
                    leftOver.CopyTo(buffer);
                    bufferStart = leftOver.Length;
                }

                read = stream.Read(buffer[bufferStart..]);
                var isFinal = read < bytesConsumed;
                Console.WriteLine($"Updating buffer ... leftOver bytes: {bufferStart}; bytes read: {read}; isFinalBlock: {isFinal}");

                if (read == 0)
                {
                    return false;
                }

                reader = new Utf8JsonReader(buffer, isFinalBlock: isFinal, reader.CurrentState);
                return true;
            }

            /*
            Produces this output:
            String in buffer is: {
                "Date": "2019-08-01T00:00:00-07:00",
                "Temperature":
            Updating buffer ... leftOver bytes: 0; bytes read: 64; isFinalBlock: False
            Updating buffer ... leftOver bytes: 3; bytes read: 61; isFinalBlock: False
            Updating buffer ... leftOver bytes: 0; bytes read: 27; isFinalBlock: True
            Found Summary value: Hot
            String in buffer is: ,
                "Summary": "Hot",
            }
            */
        }
    }
}
