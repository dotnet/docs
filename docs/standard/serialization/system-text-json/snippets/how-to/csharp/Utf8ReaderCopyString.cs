using System.Buffers;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class Utf8ReaderCopyString
    {
        public static void Run()
        {
            // <Snippet1>
            var reader = new Utf8JsonReader( /* jsonReadOnlySpan */ );

            int valueLength = reader.HasValueSequence
                ? checked((int)reader.ValueSequence.Length)
                : reader.ValueSpan.Length;

            char[] buffer = ArrayPool<char>.Shared.Rent(valueLength);
            int charsRead = reader.CopyString(buffer);
            ReadOnlySpan<char> source = buffer.AsSpan(0, charsRead);

            // Handle the unescaped JSON string.
            ParseUnescapedString(source);
            ArrayPool<char>.Shared.Return(buffer, clearArray: true);

            void ParseUnescapedString(ReadOnlySpan<char> source)
            {
                // ...
            }
            // </Snippet1>
        }
    }
}
