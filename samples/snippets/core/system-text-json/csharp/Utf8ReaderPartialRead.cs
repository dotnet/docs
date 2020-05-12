using System;
using System.IO;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class Utf8ReaderPartialRead
    {
        public static void Run()
        {
            var jsonString = @"{
                ""Date"": ""2019-08-01T00:00:00-07:00"",
                ""Temperature"": 25,
                ""TemperatureRanges"": {
                    ""Cold"": { ""High"": 20, ""Low"": -10 },
                    ""Hot"": { ""High"": 60, ""Low"": 20 }
                },
                ""Summary"": ""Hot"",
            }";

            var bytes = System.Text.Encoding.UTF8.GetBytes(jsonString.Trim());
            var stream = new MemoryStream(bytes);

            var buffer = new byte[10];
            var span = new Span<byte>(buffer);

            // Fill the buffer
            var read = stream.Read(span);

            var reader = new Utf8JsonReader(span, false, state: default);
            Console.WriteLine($"String in buffer is: {System.Text.Encoding.UTF8.GetString(span)}");

            // Search for "Summary" property name
            while (reader.TokenType != JsonTokenType.PropertyName || reader.GetString() != "Summary")
            {
                if (!reader.Read())
                {
                    // Not enough of the JSON is in the buffer to complete a read.
                    GetMoreBytesFromStream(stream, ref buffer, ref span, ref reader);
                }
            }

            Console.WriteLine($"Found property name: {reader.GetString()}");
            Console.WriteLine($"String in buffer is: {System.Text.Encoding.UTF8.GetString(span)}");
            while (!reader.Read())
            {
                // Not enough of the JSON is in the buffer to complete a read.
                GetMoreBytesFromStream(stream, ref buffer, ref span, ref reader);
            }
            System.Console.WriteLine($"Got property value: {reader.GetString()}");
        }

        private static void GetMoreBytesFromStream(MemoryStream stream, ref byte[] buffer, ref Span<byte> span, ref Utf8JsonReader reader)
        {
            if (reader.BytesConsumed < span.Length)
            {
                ReadOnlySpan<byte> leftover = span.Slice((int)reader.BytesConsumed);

                if (leftover.Length == span.Length)
                {
                    Array.Resize(ref buffer, buffer.Length * 2);
                    span = new Span<byte>(buffer);
                    Console.WriteLine($"Increased buffer size to {buffer.Length}");
                }

                leftover.CopyTo(span);
                stream.Read(span.Slice(leftover.Length));
            }
            else
            {
                stream.Read(span);
            }
            Console.WriteLine($"String in buffer is: {System.Text.Encoding.UTF8.GetString(span)}");
            reader = new Utf8JsonReader(span, false, reader.CurrentState);
        }
    }
}
