using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class ValueTextEqualsExample
    {
        // <SnippetDefineUtf8Var>
        private static readonly byte[] s_nameUtf8 = Encoding.UTF8.GetBytes("name");
        // </SnippetDefineUtf8Var>
        public static void Run(ReadOnlySpan<byte> jsonReadOnlySpan)
        {
            int count = 0;
            int total = 0;
            var reader = new Utf8JsonReader(jsonReadOnlySpan);

            // <SnippetUseUtf8Var>
            while (reader.Read())
            {
                JsonTokenType tokenType = reader.TokenType;

                switch (tokenType)
                {
                    case JsonTokenType.StartObject:
                        total++;
                        break;
                    case JsonTokenType.PropertyName:
                        if (reader.ValueTextEquals(s_nameUtf8))
                        {
                            count++;
                        }
                        break;
                }
                // </SnippetUseUtf8Var>
            }
            Console.WriteLine($"{count} out of {total} have \"name\" properties");
        }
    }
}
